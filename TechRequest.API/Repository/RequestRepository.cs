using Microsoft.EntityFrameworkCore;
using TechRequest.API.Dtos.Request;
using TechRequest.API.Interfaces;
using TechRequest.API.Models;

namespace TechRequest.API.Repository
{
    public class RequestRepository(Context context, IConverter<Request, RequestDto> converter) : IRequestRepository
    {
        //private readonly Context _dbContext;
        //private readonly IConverter<Request, RequestDto> _converter;
        // риадонли

        //public RequestRepository(Context context, IConverter<Request, RequestDto> converter)
        //{
        //    _dbContext = context;
        //    _converter = converter;
        //}

        public async Task<List<RequestDto>> GetAllAsync()
        {
            var requests = await context.Requests
                   .Include(r => r.Applicant)
                   .Include(r => r.Executors)
                   .ToListAsync();

            return requests.Select(converter.Convert).ToList();
        }

        public async Task<RequestDto?> GetByIdAsync(int id)
        {
            var request = await context.Requests
                .Include(r => r.Applicant)
                .Include(r => r.Executors)
                .FirstOrDefaultAsync(r => r.RequestId == id);

            // хз почему
            if (request == null)
                return null;

            return converter.Convert(request);
        }
    }
}
