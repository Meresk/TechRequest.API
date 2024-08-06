namespace TechRequest.API.Dtos.User
{
    public class UpdateUserRequestDto
    {
        public string Login { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
