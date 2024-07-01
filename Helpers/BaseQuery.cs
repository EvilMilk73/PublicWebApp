namespace WebApi.Helpers
{
    public class BaseQuery
    {
        public int PageSize { get; set; } = 20;
        public int PageNumber { get; set; } = 1;
        public bool Paginate { get; set; } = false;

        public string SearchQuery { get; set; } = "";
        public string OrderBy { get; set; } = "id";
        public string OrderDirection { get; set; } = "Asc";
    }
}
