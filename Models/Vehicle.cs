namespace WebApi.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Fuel_Consuming { get; set; } = "";
        public string Registration_Code { get; set; } = "";

        public List<MapRoute> Routes { get; } = new List<MapRoute>();
    }
}
