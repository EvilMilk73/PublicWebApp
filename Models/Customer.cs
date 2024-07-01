namespace WebApi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string E_Mail { get; set; } = "";
        public string Tel_Number { get; set; } = "";

        public List<Waypoint> Waypoints { get; } = new List<Waypoint>();    
    }
}
