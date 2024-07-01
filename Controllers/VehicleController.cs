using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.ManagerDto;
using WebApi.DTOs.VehicleDto;
using WebApi.Models;
using WebApi.Services.VehicleService;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _service;

        public VehicleController(IVehicleService service)
        {
            _service = service;
        }

        [HttpPost("AddVehicle")]
        public async Task<ActionResult<List<GetVehicleDto>>> AddVehicle(AddVehicleDto vehicle)
        {
            return Ok(await _service.AddVehicle(vehicle));
        }

        [HttpGet]
        public async Task<ActionResult<List<GetVehicleDto>>> GetAllVehicles()
        {
            return Ok(await _service.GetAllVehicles());
        }

        [HttpGet("{id}")]
        public ActionResult<GetVehicleDto> GetVehicleById(int id)
        {
            return Ok(_service.GetVehicleById(id));
        }

        [HttpPost("Delete/{id}")]
        public async Task<ActionResult<List<GetVehicleDto>>> DeleteVehicle(int id)
        {
            try
            {
                return Ok(await _service.DeleteVehicle(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Update/{id}")]
        public async Task<ActionResult<List<GetVehicleDto>>> UpdateVehicle(int id, AddVehicleDto vehicle)
        {
            return Ok(await _service.UpdateVehicle(id, vehicle));
        }
    }

}
