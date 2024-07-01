namespace WebApi.DTOs.WaypointDto
{
    public class AddWaypointDto
    {
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Address { get; set; }
        public int? CustomerId { get; set; }
    }
}
