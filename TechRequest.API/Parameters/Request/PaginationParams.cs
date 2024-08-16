namespace TechRequest.API.Parameters.Request
{
    public class PaginationParams
    {
        public int Page { get; set; } = 1; // Номер страницы по умолчанию
        public int PageSize { get; set; } = 10; // Количество элементов на странице по умолчанию
    }
}
