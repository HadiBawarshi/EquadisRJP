using EquadisRJP.IdentityAuth.Models.Dtos;
using EquadisRJP.IdentityAuth.Public.Dtos;
using EquadisRJP.IdentityAuth.Services;
using Microsoft.AspNetCore.Mvc;

namespace EquadisRJP.IdentityAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            var result = await _authService.RegisterUserAsync(dto);
            return Ok(result);
        }

        [HttpPost("/connect/token")]
        public async Task<IActionResult> Token([FromForm] TokenRequestDto dto)
        {
            var token = await _authService.GenerateTokenAsync(dto);
            return Ok(token);
        }

    }
}
