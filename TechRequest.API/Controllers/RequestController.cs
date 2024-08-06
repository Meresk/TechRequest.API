using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechRequest.API.Interfaces;

namespace TechRequest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestRepository _requestRepository;

        public RequestController(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var requests = await _requestRepository.GetAllAsync();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
