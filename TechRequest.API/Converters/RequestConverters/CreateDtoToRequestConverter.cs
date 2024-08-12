using TechRequest.API.Dtos.Request;
using TechRequest.API.Interfaces;
using TechRequest.API.Models;

namespace TechRequest.API.Converters.RequestConverters
{
    public class CreateDtoToRequestConverter : IConverter<RequestCreationDto, Request?>
    {
        public Request? Convert(RequestCreationDto requestCreationDto)
        {
            if (requestCreationDto == null)
                return null;

            return new Request
            {
                Reason = requestCreationDto.Reason,
                Description = requestCreationDto.Description,
                ApplicantId = requestCreationDto.ApplicantId,
            };
        }
    }
}
