using TechRequest.API.Models;

namespace TechRequest.API.Interfaces
{
    public interface IUserService
    {
        User UserVerify(string login, string password);
    }
}
