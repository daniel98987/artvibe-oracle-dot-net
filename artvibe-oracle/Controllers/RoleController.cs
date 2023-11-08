using Microsoft.AspNetCore.Mvc;
using System.Data;
using artvibe_oracle.Data;
using artvibe_oracle.Infraestructura.Entidades;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace artvibe_oracle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


	public class RoleController : ControllerBase
    {
        public readonly IRole _service;
        public RoleController(IRole role)
        {
            _service = role;
        }
        // GET: api/<RoleController>
        [HttpGet("listarTodos/user")]
        public async Task<IActionResult> Get()
        {
            var response = await _service.ListarTodos();
            if (response.Estado)
                return Ok(new { Datos = response.Resultado, response.TotalItems });

            ModelState.AddModelError("Error", string.Join(",", response.Errores));
            return BadRequest(ModelState);
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RoleController>

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RoleData role)
        {
            if (role != null)
            {
                var response = await _service.Crear(role);
                if (response.Estado)
                    return Created("api/AcuerdoConvocatoria/" + response.Resultado.Id, response.Resultado);
                ModelState.AddModelError("Error", string.Join(",", response.Errores));
            }
            else
            {
                ModelState.AddModelError("ErrorPersonalizado", "Este es un error personalizado.");

            }

            return BadRequest(ModelState);
        }


        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
