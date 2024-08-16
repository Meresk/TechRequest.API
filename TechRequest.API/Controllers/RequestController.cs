using Microsoft.AspNetCore.Mvc;
using TechRequest.API.Dtos.Request;
using TechRequest.API.Interfaces;
using TechRequest.API.Parameters;
using TechRequest.API.Parameters.Request;

namespace TechRequest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController(IRequestRepository requestRepository) : ControllerBase
    {
        private readonly IRequestRepository _requestRepository = requestRepository;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] RequestQueryParams requestQueryParams)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);

                var requests = await _requestRepository.GetAllAsync(requestQueryParams);
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var request = await _requestRepository.GetByIdAsync(id);
                return Ok(request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RequestCreationDto requestDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var request = await _requestRepository.CreateAsync(requestDto);
                return Ok(request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] RequestUpdationDto requestUpdationDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var requestDto = await _requestRepository.UpdateAsync(id, requestUpdationDto);

                if (requestDto == null)
                    return NotFound();

                return Ok(requestDto);
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message); 
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var request = await _requestRepository.DeleteAsync(id);

                if (request == null)
                    return NotFound();

                //return Ok(request);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
