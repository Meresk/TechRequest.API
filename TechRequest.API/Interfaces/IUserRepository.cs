using TechRequest.API.Dtos.User;
using TechRequest.API.Models;

namespace TechRequest.API.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User> CreateAsync(string login, string password);
        Task<User?> UpdateAsync(int id, UpdateUserDto userDto);
        Task<User?> DeleteAsync(int id);
    }
}
