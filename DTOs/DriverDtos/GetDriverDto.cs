using WebApi.Models;

namespace WebApi.DTOs.DriverDtos
{
    public class GetDriverDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string E_Mail { get; set; }
        public string Tel_Number { get; set; }
        
    }
}
