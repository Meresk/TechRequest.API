namespace TechRequest.API.Parameters.Request
{
    public class RequestQueryParams
    {
        public required FilterParams Filter { get; set; }
        public required SortParams Sort { get; set; }
        public required PaginationParams Pagination { get; set; }
    }
}
