using WebApi.DTOs.WaypointDto;
using WebApi.Models;

namespace WebApi.DTOs.CustomerDtos
{
    public class GetCustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string E_Mail { get; set; }
        public string Tel_Number { get; set; }

        public List<GetWaypointDto> Waypoints { get; set; }
    }
}
