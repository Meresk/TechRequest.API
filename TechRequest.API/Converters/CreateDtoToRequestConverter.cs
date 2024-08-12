using TechRequest.API.Dtos.Request;
using TechRequest.API.Interfaces;
using TechRequest.API.Models;

namespace TechRequest.API.Converters
{
    public class CreateDtoToRequestConverter : IConverter<RequestCreationDto, Request?>
    {
        public Request? Convert(RequestCreationDto createRequestDto)
        {
            if (createRequestDto == null)
                return null;

            return new Request
            {
                Reason = createRequestDto.Reason,
                Description = createRequestDto.Description,
                ApplicantId = createRequestDto.ApplicantId,
            };
        }
    }
}
