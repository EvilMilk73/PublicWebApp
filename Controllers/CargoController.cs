using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.CargoDtos;
using WebApi.Helpers;
using WebApi.Models;
using WebApi.Services.CargoService;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CargoController : ControllerBase
    {
        private readonly ICargoService _service;

        public CargoController(ICargoService service)
        {
            _service = service;
        }

        [HttpPost("AddCargo")]
       
        public async Task<ActionResult<List<GetCargoDto>>> AddCargo(AddCargoDto cargo)
        {
            return  Ok(await _service.AddCargo(cargo));
        }

        
        [HttpGet]
        public async Task<ActionResult<List<GetCargoDto>>> GetAllCargoes([FromQuery]CargoQuery query)
        {
            return Ok(await _service.GetAllCargoes(query));
        }

        [HttpGet("{id}")]
        public ActionResult<GetCargoDto> GetCargoById(int id)
        {
            return Ok(_service.GetCargoById(id));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<List<GetCargoDto>>> DeleteCargo(int id)
        {
            try
            {
                return Ok(await _service.DeleteCargo(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult<List<GetCargoDto>>> UpdateCargo(int id,AddCargoDto cargo)
        {
            return Ok(await _service.UpdateCargo(id, cargo));
        }
    }

}
