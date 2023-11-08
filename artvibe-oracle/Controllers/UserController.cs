using Microsoft.AspNetCore.Mvc;
using artvibe_oracle.Data;
using artvibe_oracle.Data.Configurations;
using artvibe_oracle.Infraestructura.Entidades;
using artvibe_oracle.Models.userModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace artvibe_oracle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class user : ControllerBase
    {
        public readonly IUsuario _service;
        public user(IUsuario service)
        {
            _service = service;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RoleController>

        [HttpPost("Crear")]
        public async Task<IActionResult> Post([FromBody] RegisterUser user)
        {
            if (user != null)
            {
                var response = await _service.Crear(user);
                if (response.Estado)
                    return Created("api/User/" + response.Resultado.Id, response.Resultado);
                ModelState.AddModelError("Error", string.Join(",", response.Errores));
            }
            else
            {
                ModelState.AddModelError("ErrorPersonalizado", "Este es un error personalizado.");

            }

            return BadRequest(ModelState);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        // DELETE api/<ValuesController>/5
        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginDtoBase logDtoBase)
        {

            var response = await _service.Login(logDtoBase);
            if (response == null)
            {
                return Unauthorized();
            }

            return Ok(response);

        }
    }
}
