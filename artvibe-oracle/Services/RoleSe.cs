using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using artvibe_oracle.Data;
using artvibe_oracle.Infraestructura;
using artvibe_oracle.Infraestructura.Entidades;

namespace artvibe_oracle.Services
{
    public class RoleSe : IRole
    {
        private readonly RoleManager<RoleData> _roleManager;
        private readonly IResponseService _responseService;

        public RoleSe(RoleManager<RoleData> roleManager, IResponseService responseService)
        {
            _roleManager = roleManager;
            _responseService = responseService;



        }
        public Task<IResponseService> Borrar(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResponseService> Crear(RoleData entidad)
        {

            try
            {
                var result = await _roleManager.CreateAsync(entidad);
                _responseService.EstablecerRespuesta(true, entidad);
                return _responseService;
            }
            catch (Exception ex)
            {
                //_responseService.Errores.Add(_exceptionHandler.GetMessage(ex));
                _responseService.Estado = false;
                return _responseService;
            }



        }

        public Task<IResponseService> Listar(dynamic param)
        {
            throw new NotImplementedException();
        }

        public async Task<IResponseService> ListarTodos()
        {
            try
            {
                _responseService.Estado = true;
                _responseService.EstablecerRespuestaLista(true, await _roleManager.Roles.ToListAsync());
                return _responseService;
            }
            catch
            {

                _responseService.Estado = false;
                return _responseService;
            }
        }

        public Task<IResponseService> Modificar(Guid id, RoleData entidad)
        {
            throw new NotImplementedException();
        }

        public Task<IResponseService> Obtener(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
