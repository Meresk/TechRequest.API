﻿using Microsoft.AspNetCore.Mvc;
using TechRequest.API.Dtos.Request;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
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
                var request = await _requestRepository.CreateAsync(requestDto);
                return Ok(request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var request = await _requestRepository.DeleteAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
