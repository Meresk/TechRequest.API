using TechRequest.API.Dtos.Request;
using TechRequest.API.Models;

namespace TechRequest.API.Interfaces
{
    public interface IRequestRepository
    {
        Task<List<RequestDto>> GetAllAsync();

        Task<RequestDto?> GetByIdAsync(int id);

        Task<Request?> CreateAsync(RequestCreationDto createRequestDto);

        //Task<RequestDto?> UpdateAsync(int id, UpdateRequestDto);

        Task<Request?> DeleteAsync(int id);
    }
}
