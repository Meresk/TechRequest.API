using TechRequest.API.Dtos.Request;
using TechRequest.API.Interfaces;
using TechRequest.API.Models;

namespace TechRequest.API.Converters.RequestConverters
{
    public class UpdateDtoToRequestConverter : IConverter<RequestUpdationDto, Request?>
    {
        public Request? Convert(RequestUpdationDto requestUpdationDto)
        {
            if (requestUpdationDto == null)
                return null;

            return new Request
            {
                Reason = requestUpdationDto.Reason,
                Description = requestUpdationDto.Description,
            };
        }
    }
}
