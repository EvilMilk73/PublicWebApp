using WebApi.DTOs.CargoDtos;
using WebApi.DTOs.CustomerDtos;
using WebApi.Models;

namespace WebApi.DTOs.WaypointDto
{
    public class GetWaypointDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Address { get; set; }
        public GetCustomerDto Customer { get; set; }
        public List<GetCargoDto> Cargos { get; set; }
        public int? CustomerId { get; set; }
    }
}
