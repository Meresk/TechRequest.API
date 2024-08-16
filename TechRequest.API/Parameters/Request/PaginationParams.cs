using System.ComponentModel.DataAnnotations;

namespace TechRequest.API.Parameters.Request
{
    public class PaginationParams
    {
        [Range(1, int.MaxValue, ErrorMessage = "Page must be greater than 0.")]
        public int Page { get; set; } = 1; // Номер страницы по умолчанию

        [Range(1, 100, ErrorMessage = "PageSize must be between 1 and 100.")]
        public int PageSize { get; set; } = 10; // Количество элементов на странице по умолчанию
    }
}
