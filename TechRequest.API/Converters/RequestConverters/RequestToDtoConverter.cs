using TechRequest.API.Dtos.Request;
using TechRequest.API.Dtos.User;
using TechRequest.API.Interfaces;
using TechRequest.API.Models;

namespace TechRequest.API.Converters.RequestConverters
{
    public class RequestToDtoConverter( 
        IConverter<User, ApplicantDto> userToApplicantConverter,
        IConverter<User, ExecutorDto> userToExecutorConverter) 
        : IConverter<Request, RequestDto?>
    {
        private readonly IConverter<User, ApplicantDto> userToApplicantConverter = userToApplicantConverter;
        private readonly IConverter<User, ExecutorDto> userToExecutorConverter = userToExecutorConverter;

        public RequestDto? Convert(Request request)
        {
            if (request == null)
                return null;

            return new RequestDto
            {
                RequestId = request.RequestId,
                Status = request.Status,
                Reason = request.Reason,
                Description = request.Description,
                ApplicantId = request.ApplicantId,
                ApplicantDto = userToApplicantConverter.Convert(request.Applicant),
                ExecutorsDto = request.Executors.Select(userToExecutorConverter.Convert).ToList(),
            };
        }
    }
}
