using System.ComponentModel.DataAnnotations;

namespace TechRequest.API.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        public string? Login { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
