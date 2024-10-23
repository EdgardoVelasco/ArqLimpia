using Micro_Producto.Model.Entities;
using Micro_Producto.Model.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Micro_Producto.Controllers
{
    [EnableCors("AllowAllOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly IDogService _service;

        public DogController(IDogService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Dog dog) {
            var result = _service.Insert(dog);

            if (result > 0)
                return Created();
            
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetDogs() { 
            var data=_service.GetAll();

            return Ok(data);
        }

        [HttpGet("id")]
        public IActionResult GetById([FromQuery] int id)
        {
            
            try {
                var data = _service.FindById(id);
                return Ok(data);
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int id) {
            try
            {
                var data = _service.Delete(id);
                
                return Ok($"Eliminado ${data>0}");
            }
            catch (Exception ex) {
                return NotFound(ex.Message);
            }
        }


    }
}
