namespace WebApi.Helpers
{
    public class WaypointQuery : BaseQuery
    {
        public string Address { get; set; } = "'";
        public string Name { get; set; } = "'";
        public string Customer { get; set; } = "'";
        public string CustomersIds { get; set; } = ""; //ids dividev by comma
    }
}
