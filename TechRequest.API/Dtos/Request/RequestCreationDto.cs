namespace TechRequest.API.Dtos.Request
{
    public class RequestCreationDto
    {
        public string Reason { get; set; } = null!;

        public string? Description { get; set; }

        public int ApplicantId { get; set; }
    }
}
