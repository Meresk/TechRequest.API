using Microsoft.EntityFrameworkCore;
using TechRequest.API.Dtos.Request;
using TechRequest.API.Interfaces;
using TechRequest.API.Mappers;
using TechRequest.API.Models;

namespace TechRequest.API.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly Context _dbContext;

        public RequestRepository(Context context)
        {
            _dbContext = context;
        }

        public async Task<List<RequestDto>> GetAllAsync()
        {
            var requests = await _dbContext.Requests
                   .Include(r => r.Applicant)
                   .Include(r => r.Executors)
                   .ToListAsync();

            return requests.Select(r => r.ToRequestDto()).ToList();
        }
    }
}
