using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.WaypointDto;
using WebApi.Helpers;
using WebApi.Models;
using WebApi.Services.WaypointService;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WaypointController : ControllerBase
    {
        private readonly IWaypointService _service;

        public WaypointController(IWaypointService service)
        {
            _service = service;
        }

        [HttpPost("AddWaypoint")]
        public async Task<ActionResult<List<GetWaypointDto>>> AddWaypoint(AddWaypointDto waypoint)
        {
            return Ok(await _service.AddWaypoint(waypoint));
        }

        [HttpGet]
        public async Task<ActionResult<List<GetWaypointDto>>> GetAllWaypoints([FromQuery]WaypointQuery query)
        {
            return Ok(await _service.GetAllWaypoints(query));
        }

        [HttpGet("{id}")]
        public ActionResult<GetWaypointDto> GetWaypointById(int id)
        {
            return Ok(_service.GetWaypointById(id));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<List<GetWaypointDto>>> DeleteWaypoint(int id)
        {
            try
            {
                return Ok(await _service.DeleteWaypoint(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult<List<GetWaypointDto>>> UpdateWaypoint(int id, AddWaypointDto waypoint)
        {
            return Ok(await _service.UpdateWaypoint(id, waypoint));
        }
    }

}
