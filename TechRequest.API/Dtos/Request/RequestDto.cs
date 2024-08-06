using TechRequest.API.Dtos.User;

namespace TechRequest.API.Dtos.Request
{
    public class RequestDto
    {
        public int RequestId { get; set; }

        public string Reason { get; set; } = null!;

        public string? Description { get; set; }

        public int ApplicantId { get; set; }

        public virtual ApplicantDto Applicant { get; set; } = null!;

        //public virtual ICollection<User> Executors { get; set; } = new List<User>();
    }
}
