using WebApi.Models;

namespace WebApi.DTOs.CargoDtos
{
    public class AddCargoDto
    {
        public int Size { get; set; }
        public int Weight { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public int? WaypointId { get; set; }
       
        public int? RouteId { get; set; }
    }
}
