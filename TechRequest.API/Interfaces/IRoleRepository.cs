using TechRequest.API.Models;

namespace TechRequest.API.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllAsync();
        Task<Role?> GetByIdAsync(int id);
    }
}
