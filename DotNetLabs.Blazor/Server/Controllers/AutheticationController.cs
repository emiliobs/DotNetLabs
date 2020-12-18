using DotNetLabs.Blazor.Shared;
using DotNetLabs.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            this._userService = userService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest model)
        {
            var loginResponse = await _userService.GenerateTokenAsync(model);
            if (loginResponse == null)
                return BadRequest("Invalid UserName or Password");

            return Ok(loginResponse);
        }

    }
}
