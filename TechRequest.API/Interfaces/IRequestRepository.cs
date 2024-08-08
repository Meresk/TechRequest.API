using TechRequest.API.Dtos.Request;
using TechRequest.API.Models;

namespace TechRequest.API.Interfaces
{
    public interface IRequestRepository
    {
        Task<List<RequestDto?>> GetAllAsync();

        Task<RequestDto?> GetByIdAsync(int id);
    }
}
