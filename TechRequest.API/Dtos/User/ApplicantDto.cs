namespace TechRequest.API.Dtos.User
{
    public class ApplicantDto
    {
        public int UserId { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Patronymic { get; set; }

        public string Login { get; set; } = null!;
    }
}
