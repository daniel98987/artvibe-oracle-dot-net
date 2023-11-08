using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using artvibe_oracle.Data;
using artvibe_oracle.Infraestructura.Entidades;
using artvibe_oracle.Models.ProductType;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace artvibe_oracle.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	[Authorize]

	public class TypeOfProductController : ControllerBase
    {
        public readonly IProductTypeDate _service;
        public readonly IMapper _mapper;
        public TypeOfProductController(IMapper mapper, IProductTypeDate productType)
        {
            _service = productType;
            _mapper = mapper;
        }
        // GET: api/<TypeOfProductController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TypeOfProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TypeOfProductController>
        [HttpPost]
        public async Task<ActionResult<ProductTypeDate>> Post([FromBody] CreateProductTypeModel entidad)
        {
            var productTypeDate = _mapper.Map<ProductTypeDate>(entidad);
            var response = await _service.Crear(productTypeDate);
            if (response.Estado)
                return Created("api/AgregadoVerificacions/" + response.Resultado.Id, response.Resultado);
            return BadRequest(response);




        }

        // PUT api/<TypeOfProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TypeOfProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
