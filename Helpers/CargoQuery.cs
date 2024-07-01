namespace WebApi.Helpers
{
    public class CargoQuery: BaseQuery
    {
        public string Size { get; set; } = "";
        public string Weight { get; set; } = "";
        public string Date { get; set; } = "";
    }
}
