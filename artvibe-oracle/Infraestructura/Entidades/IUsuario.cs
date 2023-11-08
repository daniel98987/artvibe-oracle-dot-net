using artvibe_oracle.Data;
using artvibe_oracle.Data.Configurations;
using artvibe_oracle.Models.userModel;

namespace artvibe_oracle.Infraestructura.Entidades
{

    public interface IUsuario
    {
        Task<IResponseService> Obtener(Guid id);
        Task<IResponseService> Listar();
        Task<IResponseService> ListarTodos();
        Task<IResponseService> Crear(RegisterUser register);
        Task<IResponseService> Modificar(Guid id, UserData entidad);
        Task<IResponseService> Borrar(Guid id);
        Task<AuthResponseDto> Login(LoginDtoBase loginDtoBase);
        //Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request);

    }
}
