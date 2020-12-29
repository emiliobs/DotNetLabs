using DotNetLabs.Blazor.Shared;
using DotNetLabs.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DotNetLabs.Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlayListsController : ControllerBase
    {
        private readonly IPlayListServices _playListServices;

        public PlayListsController(IPlayListServices playListServices)
        {
            _playListServices = playListServices;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(PlayListDetail playListDetail)
        {
            var result = await _playListServices.CreatePlayListDetailAsync(playListDetail);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
