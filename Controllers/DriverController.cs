using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services.DriverService;
using WebApi.DTOs.DriverDtos;
namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _service;

        public DriverController(IDriverService service)
        {
            _service = service;
        }

        [HttpPost("AddDriver")]
        public async Task<ActionResult<List<GetDriverDto>>> AddDriver(AddDriverDto driver)
        {
            return Ok(await _service.AddDriver(driver));
        }

        [HttpGet]
        public async Task<ActionResult<List<GetDriverDto>>> GetAllDrivers()
        {
            return Ok(await _service.GetAllDrivers());
        }

        [HttpGet("{id}")]
        public ActionResult<GetDriverDto> GetDriverById(int id)
        {
            return Ok(_service.GetDriverById(id));
        }

        [HttpPost("Delete/{id}")]
        public async Task<ActionResult<List<GetDriverDto>>> DeleteDriver(int id)
        {
            try
            {
                return Ok(await _service.DeleteDriver(id));
            }
            catch (Exception ex)                //fix
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Update/{id}")]
        public async Task<ActionResult<List<GetDriverDto>>> UpdateDriver(int id, AddDriverDto driver)
        {
            return Ok(await _service.UpdateDriver(id, driver));
        }
    }

}
