namespace TechRequest.API.Parameters.Request
{
    public class RequestQueryParams
    {
        public FilterParams? Filter { get; set; } = null;
        public SortParams? Sort { get; set; } = null;
        public PaginationParams Pagination { get; set; } = new PaginationParams();
    }
}
