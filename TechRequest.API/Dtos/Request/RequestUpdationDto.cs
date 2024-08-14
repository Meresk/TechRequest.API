namespace TechRequest.API.Dtos.Request
{
    public class RequestUpdationDto
    {
        public required string Status { get; set; }

        public string Reason { get; set; } = null!;

        public string? Description { get; set; }
    }
}
