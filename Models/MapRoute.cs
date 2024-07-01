namespace WebApi.Models
{
    public class MapRoute
    {
        public int Id { get; set; }
       
        public string Distance { get; set; } = "";
       
        public int? ManagerId { get; set; }
        public Manager? Manager { get; set; }
       
        public int? DriverId { get; set; }
        public Driver? Driver { get; set; }
       
        public int? VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
        
        public List<Cargo> Cargos { get;}
    }
}
