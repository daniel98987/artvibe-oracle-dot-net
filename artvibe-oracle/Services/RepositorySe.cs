using artvibe_oracle.Data;
using artvibe_oracle.Infraestructura.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace artvibe_oracle.Services
{
    public class RepositorySe<T> : IRepositorio<T> where T : class, new()
    {
        private readonly DbContextartvibe_oracle _db;

        public RepositorySe(DbContextartvibe_oracle db)
        {
            _db = db;
        }


        private static IQueryable<T> PerformInclusions(IEnumerable<Expression<Func<T, object>>> includeProperties, IQueryable<T> query) => includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

        public IQueryable<T> AsQueryable() => _db.Set<T>().AsQueryable();

        //public async Task<IEnumerable<T>> GetPagedAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, Expression<Func<T, bool>> filter = null, int page = 1, int pageSize = 20,
        //    params Expression<Func<T, object>>[] includeProperties)
        //{
        //    if (page < 1) throw new ApplicationException("La pagina debe ser mayor a cero");
        //    var query = AsQueryable();
        //    query = PerformInclusions(includeProperties, query);
        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }
        //    query = orderBy(query);
        //    query = query.Skip((page - 1) * pageSize).Take(pageSize);
        //    return await query.ToListAsync();
        //}

        public async Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            if (filter != null)
            {
                query = query.Where(filter);
            }
            query = orderBy(query);
            return await query.ToListAsync();
        }

        //public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        //{
        //    var query = AsQueryable();
        //    query = PerformInclusions(includeProperties, query);
        //    var item = await query.FirstOrDefaultAsync(where);
        //    if (item == null) DataEmpty(query);
        //    return item;
        //}

        //internal static void DataEmpty(IQueryable<T> query, bool isList = false)
        //{
        //    var entityName = query.GetType().ToString().Split('[').FirstOrDefault(x => x.Contains("Entidades"))?.Split('.').ElementAt(3);
        //    entityName = Regex.Replace(entityName ?? throw new InvalidOperationException(), "[^a-zA-Z]", "", RegexOptions.None);
        //    entityName = ResourceHandler.GetValueResource(ResourceName.EntitiesName, entityName);
        //    if (isList) throw new ApplicationException(string.Format(Errors.DataNotFound, entityName));
        //    throw new ApplicationException(string.Format(Errors.RecordNotFound, entityName));
        //}

        //public void Delete(T entity) => _db.Set<T>().Remove(entity);


        public void Insert(T entity) => _db.Set<T>().Add(entity);

        //public void Update(T entity) => _db.Entry(entity).State = EntityState.Modified;

        //public void Insert(IEnumerable<T> entities) => entities.ToList().ForEach(x => _db.Entry(x).State = EntityState.Added);

        //public void Update(IEnumerable<T> entities) => entities.ToList().ForEach(x => _db.Entry(x).State = EntityState.Modified);

        //public void Delete(IEnumerable<T> entities) => entities.ToList().ForEach(x => _db.Entry(x).State = EntityState.Deleted);




    }
}
