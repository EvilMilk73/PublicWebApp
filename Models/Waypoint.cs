namespace WebApi.Models
{
    public class Waypoint
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Latitude { get; set; } = "";
        public string Longitude { get; set; } = "";

        public string Address { get; set; } = "";
        
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public List<Cargo> Cargos { get; } = new List<Cargo>();
    }
}

