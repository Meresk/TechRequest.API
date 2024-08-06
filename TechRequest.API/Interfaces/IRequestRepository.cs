using TechRequest.API.Models;

namespace TechRequest.API.Interfaces
{
    public interface IRequestRepository
    {
        Task<List<Request>> GetAllAsync();
    }
}
