using Microsoft.EntityFrameworkCore;
using TechRequest.API.Interfaces;
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

        public async Task<List<Request>> GetAllAsync()
        {
            return await _dbContext.Requests.Include(a => a.Applicant).Include(e => e.Executors).ToListAsync();
        }
    }
}
