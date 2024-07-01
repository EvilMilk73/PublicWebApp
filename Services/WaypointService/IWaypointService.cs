using WebApi.DTOs.WaypointDto;
using WebApi.Models;
using WebApi.Helpers;
namespace WebApi.Services.WaypointService
{
    public interface IWaypointService
    {
        Task<List<GetWaypointDto>> GetAllWaypoints(WaypointQuery query);
        GetWaypointDto GetWaypointById(int id);
        Task<List<GetWaypointDto>> AddWaypoint(AddWaypointDto waypoint);
        Task<List<GetWaypointDto>> UpdateWaypoint(int id, AddWaypointDto waypoint);
        Task<List<GetWaypointDto>> DeleteWaypoint(int id);
    }
}
