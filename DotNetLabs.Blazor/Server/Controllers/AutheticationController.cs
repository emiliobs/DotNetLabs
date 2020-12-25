using DotNetLabs.Blazor.Shared;
using DotNetLabs.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DotNetLabs.Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutheticationController : ControllerBase
    {
        private readonly IUserService _userService;

        public AutheticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest model)
        {
            var result = await _userService.GenerateTokenAsync(model);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest model)
        {
            var result = await _userService.RegisterUserAsync(model);

            if (result.IsSuccess)
                return Ok(result);


            return BadRequest(result);
        }

    }
}
