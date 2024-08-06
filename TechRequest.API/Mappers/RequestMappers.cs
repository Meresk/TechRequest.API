using TechRequest.API.Dtos.Request;
using TechRequest.API.Models;

namespace TechRequest.API.Mappers
{
    public static class RequestMappers
    {
        public static RequestDto ToRequestDto(this Request request)
        {
            return new RequestDto
            {
                RequestId = request.RequestId,
                Reason = request.Reason,
                Description = request.Description,
                ApplicantId = request.ApplicantId,
                ApplicantDto = request.Applicant.ToApplicantDto(),
                ExecutorsDto = request.Executors.Select(user => user.ToExecutorDto()).ToList()
            };
        }
    }
}
