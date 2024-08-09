using TechRequest.API.Dtos.Request;
using TechRequest.API.Dtos.User;
using TechRequest.API.Interfaces;
using TechRequest.API.Models;

namespace TechRequest.API.Converters
{
    public class RequestConverter(IConverter<User, ApplicantDto> userToApplicantConverter, IConverter<User, ExecutorDto> userToExecutorConverter)
        : IConverter<Request, RequestDto?>
    {
        public RequestDto? Convert(Request request)
        {
            if (request == null)
                return null;

            return new RequestDto
            {
                RequestId = request.RequestId,
                Reason = request.Reason,
                Description = request.Description,
                ApplicantId = request.ApplicantId,
                ApplicantDto = userToApplicantConverter.Convert(request.Applicant),
                ExecutorsDto = request.Executors.Select(userToExecutorConverter.Convert).ToList(),
            };
        }
    }
}
