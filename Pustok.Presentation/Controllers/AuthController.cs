using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pustok.Buisness.Dtos.UserDtos;
using Pustok.Buisness.Services.Abstractions;
using System.Security.Claims;

namespace Pustok.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService _service, IJwtService _jwtService) : ControllerBase
    {

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _service.RegisterAsync(dto);

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _service.LoginAsync(dto);

            return Ok(result);
        }


    }
}
