using TechRequest.API.Dtos.Request;
using TechRequest.API.Parameters;
using TechRequest.API.Parameters.Request;

namespace TechRequest.API.Interfaces
{
    public interface IRequestRepository
    {
        Task<List<RequestDto>> GetAllAsync(RequestQueryParams requestQueryParams);

        Task<RequestDto?> GetByIdAsync(int id);

        Task<RequestDto?> CreateAsync(RequestCreationDto requestCreationDto);

        Task<RequestDto?> UpdateAsync(int id, RequestUpdationDto requestUpdationDto);

        Task<RequestDto?> DeleteAsync(int id);
    }
}
