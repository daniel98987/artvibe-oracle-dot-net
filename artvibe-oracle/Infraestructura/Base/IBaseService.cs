namespace artvibe_oracle.Infraestructura.Base
{
    public interface IBaseService<in T>
    {
        Task<IResponseService> Obtener(Guid id);
        Task<IResponseService> Listar(dynamic param);
        Task<IResponseService> ListarTodos();
        Task<IResponseService> Crear(T entidad);
        Task<IResponseService> Modificar(Guid id, T entidad);
        Task<IResponseService> Borrar(Guid id);
    }
}
