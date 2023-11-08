using artvibe_oracle.Data;
using artvibe_oracle.Infraestructura.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace artvibe_oracle.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class Fruits : ControllerBase
	{
		public readonly IFruits _service;
		public readonly IMapper _mapper;
		public Fruits(IMapper mapper, IFruits fruits)
		{
			_service = fruits;
			_mapper = mapper;
		}

		// GET: api/<RoleController>
		[HttpPost()]
		public async Task<IActionResult> Post([FromBody] DateFruit fruitPost)
		{
			var response = await _service.Crear(fruitPost);
			if (response.Estado)
				return Ok(new { Datos = response.Resultado, response.TotalItems });

			ModelState.AddModelError("Error", string.Join(",", response.Errores));
			return BadRequest(ModelState);
		}

		// GET: api/<RoleController>
		[HttpGet()]
		public async Task<IActionResult> Get()
		{
			var response = await _service.ListarTodos();
			if (response.Estado)

				return Ok(new { Datos = response.Resultado, response.TotalItems });

			ModelState.AddModelError("Error", string.Join(",", response.Errores));
			return BadRequest(ModelState);
		}
	}
}
