﻿using System.ComponentModel.DataAnnotations;

namespace TechRequest.API.Dtos.Account
{
    public class LoginDto
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
