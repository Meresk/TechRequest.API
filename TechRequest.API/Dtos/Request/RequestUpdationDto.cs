using System.ComponentModel.DataAnnotations;

namespace TechRequest.API.Dtos.Request
{
    public class RequestUpdationDto
    {
        [Required(ErrorMessage = "Status is required.")]
        public required string Status { get; set; }

        [Required(ErrorMessage = "Reason is required.")]
        public required string Reason { get; set; }

        [MaxLength(280, ErrorMessage = "Description cannot be over 280 characters.")]
        public string? Description { get; set; }
    }
}
