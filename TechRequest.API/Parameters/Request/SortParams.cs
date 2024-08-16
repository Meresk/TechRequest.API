namespace TechRequest.API.Parameters.Request
{
    public class SortParams
    {
        public string SortBy { get; set; } = "id";  // Значение по умолчанию: сортировка по id
        public bool Descending { get; set; } = false; // Значение по умолчанию: сортировка по возрастанию
    }
}
