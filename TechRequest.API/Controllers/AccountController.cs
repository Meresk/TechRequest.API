using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechRequest.API.Data;
using TechRequest.API.Dtos.Account;
using TechRequest.API.Interfaces;
using TechRequest.API.Models;

namespace TechRequest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(Context dbContext, IUserService userService, ITokenService tokenService, IUserRepository userRepository) : ControllerBase
    {
        private readonly Context _dbContext = dbContext;
        private readonly IUserService _userService = userService;
        private readonly ITokenService _tokenService = tokenService;
        private readonly IUserRepository _userRepository = userRepository;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = await _userRepository.CreateAsync(login: registerDto.Login, password: registerDto.Password);

                if (user == null)
                    return Conflict("User with this login already exists.");

                return CreatedAtAction(nameof(Register), new { id = user.UserId }, "User created successfully.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _userService.UserVerify(loginDto.Login, loginDto.Password);

            if (user == null)
                return BadRequest(ModelState);

            //TODO переделать под Repository паттерн
            user.RefreshToken = Guid.NewGuid().ToString();
            _dbContext.SaveChanges();

            Response.Cookies.Append("A", _tokenService.CreateToken(user));
            Response.Cookies.Append("AR", user.RefreshToken);
            Response.Cookies.Append("U", user.Login);

            return Ok();
        }

        [HttpPost("Refresh")]
        public async Task<IActionResult> RefreshToken()
        {
            if (!(Request.Cookies.TryGetValue("U", out var login) && Request.Cookies.TryGetValue("AR", out var refreshToken)))
                return BadRequest();

            var user = _dbContext.Users.FirstOrDefault(u => u.Login == login && u.RefreshToken == refreshToken);

            if (user == null)
                return BadRequest();

            user.RefreshToken = Guid.NewGuid().ToString();
            _dbContext.SaveChanges();

            Response.Cookies.Append("A", _tokenService.CreateToken(user));
            Response.Cookies.Append("AR", user.RefreshToken);
            Response.Cookies.Append("U", user.Login);

            return Ok();
        }
    }
}
