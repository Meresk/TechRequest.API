using TechRequest.API.Models;

namespace TechRequest.API.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
