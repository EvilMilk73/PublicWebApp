using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.ManagerDto;
using WebApi.Models;
using WebApi.Services.ManagerService;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _service;

        public ManagerController(IManagerService service)
        {
            _service = service;
        }

        [HttpPost("AddManager")]
        public async Task<ActionResult<List<GetManagerDto>>> AddManager(AddManagerDto manager)
        {
            return  Ok(await _service.AddManager(manager));
        }

        [HttpGet]
        public async Task<ActionResult<List<GetManagerDto>>> GetAllManagers()
        {
            return  Ok(await _service.GetAllManagers());
        }

        [HttpGet("{id}")]
        public ActionResult<GetManagerDto> GetManagerById(int id)
        {
            return Ok(_service.GetManagerById(id));
        }

        [HttpPost("Delete/{id}")]
        public async Task<ActionResult<List<GetManagerDto>>> DeleteManager(int id)
        {
            try
            {
                return Ok(await _service.DeleteManager(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Update/{id}")]
        public async Task<ActionResult<List<GetManagerDto>>> UpdateManager(int id, AddManagerDto manager)
        {
            return Ok(await _service.UpdateManager(id, manager));
        }
    }

}
