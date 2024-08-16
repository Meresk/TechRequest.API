using Microsoft.EntityFrameworkCore;
using TechRequest.API.Dtos.Request;
using TechRequest.API.Interfaces;
using TechRequest.API.Models;
using TechRequest.API.Parameters;

namespace TechRequest.API.Repository
{
    public class RequestRepository(
        Context context,
        IConverter<Request, RequestDto> converter,
        IConverter<RequestCreationDto, Request> createConverter) : IRequestRepository
    {
        private readonly Context _dbContext = context;
        private readonly IConverter<Request, RequestDto> _converter = converter;
        private readonly IConverter<RequestCreationDto, Request> _createConverter = createConverter;

        public async Task<List<RequestDto>> GetAllAsync()
        {
            var requests = await _dbContext.Requests
                   .Include(r => r.Applicant)
                   .Include(r => r.Executors)
                   .ToListAsync();

            return requests.Select(_converter.Convert).ToList();
        }

        public async Task<RequestDto?> GetByIdAsync(int id)
        {
            var request = await _dbContext.Requests
                .Include(r => r.Applicant)
                .Include(r => r.Executors)
                .FirstOrDefaultAsync(r => r.RequestId == id);

            // хз почему
            if (request == null)
                return null;

            return _converter.Convert(request);
        }

        public async Task<RequestDto?> CreateAsync(RequestCreationDto requestCreationDto)
        {
            var request = _createConverter.Convert(requestCreationDto);

            await _dbContext.Requests.AddAsync(request);
            await _dbContext.SaveChangesAsync();

            return await GetByIdAsync(request.RequestId);
        }

        public async Task<RequestDto?> UpdateAsync(int id, RequestUpdationDto requestUpdationDto)
        {
            var existingRequest = await _dbContext.Requests.FirstOrDefaultAsync(r => r.RequestId == id);

            if (existingRequest == null)
                return null;

            existingRequest.Status = requestUpdationDto.Status;
            existingRequest.Description = requestUpdationDto.Description;
            existingRequest.Reason = requestUpdationDto.Reason;

            await _dbContext.SaveChangesAsync();

            return await GetByIdAsync(existingRequest.RequestId);
        }

        public async Task<RequestDto?> DeleteAsync(int id)
        {
            var requestModel = await _dbContext.Requests.FirstOrDefaultAsync(r => r.RequestId == id);

            if (requestModel == null)
            {
                return null;
            }

            var dtoToReturn = await GetByIdAsync(requestModel.RequestId);

            _dbContext.Requests.Remove(requestModel);
            await _dbContext.SaveChangesAsync();

            return dtoToReturn;
        }
    }
}
