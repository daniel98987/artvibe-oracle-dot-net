using artvibe_oracle.Data;
using artvibe_oracle.Infraestructura;
using artvibe_oracle.Infraestructura.Base;
using artvibe_oracle.Infraestructura.Entidades;
using AutoMapper;

namespace artvibe_oracle.Services
{
	public class FruitSe : IFruits
	{
		private readonly IRepositorio<DateFruit> _repositorio;
		private readonly DbContextartvibe_oracle _contexto;
		private readonly IResponseService _responseService;
		private readonly IMapper _mapper;
		public FruitSe(IRepositorio<DateFruit> repositorio, IMapper mapper, DbContextartvibe_oracle contexto, IResponseService responseService)
		{
			_repositorio = repositorio;
			_contexto = contexto;
			_responseService = responseService;
			this._mapper = mapper;
		}
		public Task<IResponseService> Borrar(Guid id)
		{
			throw new NotImplementedException();
		}

		async Task<IResponseService> IBaseService<DateFruit>.Crear(DateFruit entidad)
		{
			try
			{


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


		public Task<IResponseService> Listar(dynamic param)
		{
			throw new NotImplementedException();
		}

		public async Task<IResponseService> ListarTodos()
		{
			try { 
				var real = await _repositorio.GetAllAsync(o => o.OrderBy(x => x.FechaDeCosecha));

				_responseService.EstablecerRespuestaLista(true, await _repositorio.GetAllAsync(o => o.OrderBy(x => x.FechaDeCosecha)));
				return _responseService;
			}
			catch (Exception ex)
			{
				_responseService.Errores.Add(ex.Message);
				_responseService.Estado = false;
				return _responseService;
			}
		}

		public Task<IResponseService> Modificar(Guid id, DateFruit entidad)
		{
			throw new NotImplementedException();
		}

		public Task<IResponseService> Obtener(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
