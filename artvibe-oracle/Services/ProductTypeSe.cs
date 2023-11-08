using AutoMapper;
using artvibe_oracle.Data;
using artvibe_oracle.Infraestructura;
using artvibe_oracle.Infraestructura.Base;
using artvibe_oracle.Infraestructura.Entidades;

namespace artvibe_oracle.Services
{
	public class ProductTypeSe : IProductTypeDate
	{
		private readonly IRepositorio<ProductTypeDate> _repositorio;
		private readonly DbContextartvibe_oracle _contexto;
		private readonly IResponseService _responseService;
		private readonly IMapper _mapper;
		public ProductTypeSe(IRepositorio<ProductTypeDate> repositorio, IMapper mapper, DbContextartvibe_oracle contexto, IResponseService responseService)
		{
			_repositorio = repositorio;
			_contexto = contexto;
			_responseService = responseService;
			this._mapper = mapper;
		}

		Task<IResponseService> IBaseService<ProductTypeDate>.Borrar(Guid id)
		{
			throw new NotImplementedException();
		}

		async Task<IResponseService> IBaseService<ProductTypeDate>.Crear(ProductTypeDate entidad)
		{
			try
			{

				//await _contexto.AddAsync(entidad);
				// await _contexto.SaveChangesAsync();
				_repositorio.Insert(entidad);
				_responseService.EstablecerRespuesta(await _contexto.SaveChangesAsync() > 0, entidad);
				return _responseService;
			}
			catch (Exception ex)
			{
				_responseService.Errores.Add(ex.Message);
				_responseService.Estado = false;
				return _responseService;
			}
		}

		Task<IResponseService> IBaseService<ProductTypeDate>.Listar(dynamic param)
		{
			throw new NotImplementedException();
		}

		Task<IResponseService> IBaseService<ProductTypeDate>.ListarTodos()
		{
			throw new NotImplementedException();
		}

		Task<IResponseService> IBaseService<ProductTypeDate>.Modificar(Guid id, ProductTypeDate entidad)
		{
			throw new NotImplementedException();
		}

		Task<IResponseService> IBaseService<ProductTypeDate>.Obtener(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
