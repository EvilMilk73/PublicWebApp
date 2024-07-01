using WebApi.DTOs.WaypointDto;
using WebApi.Models;

namespace WebApi.DTOs.CargoDtos
{
    public class GetCargoDto
    {
        public int Id { get; set; } 
        public int Size { get; set; }
        public int Weight { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public int? WaypointId { get; set; }
        public GetWaypointDto? Waypoint { get; set; }
        public int? RouteId { get; set; }
    }
}
