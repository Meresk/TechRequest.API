using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using TechRequest.API.Interfaces;
using TechRequest.API.Models;

namespace TechRequest.API.Services
{
    public class UserService(Context context) : IUserService
    {
        private readonly Context _dbContext = context;

        public User? UserVerify(string login, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Login == login);

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return user;
            }

            return null;
        }
    }
}
