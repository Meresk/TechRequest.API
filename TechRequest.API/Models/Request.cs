using System;
using System.Collections.Generic;

namespace TechRequest.API.Models;

public partial class Request
{
    public int RequestId { get; set; }

    public string Reason { get; set; } = null!;

    public string? Description { get; set; }

    public int ApplicantId { get; set; }

    public virtual User Applicant { get; set; } = null!;

    public virtual ICollection<User> Executors { get; set; } = new List<User>();
}
