using Ajax;
using ChiliLabsHomework.Services;
using ChiliLabsHomework.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChiliLabsHomework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AvatarController : ControllerBase
    {
        private readonly IAvatarService _avatarService;
        public AvatarController(IAvatarService avatarService)
        {
            _avatarService = avatarService;
        }

        [HttpPost("Upload")]
        public IActionResult UploadAvatar(string nickname, IFormFile avatar)
        {
            var result = _avatarService.UploadAvatar(nickname, avatar);
            if (result.status == "success")
            {
                return Ok(result.data);
            }
            return BadRequest(result.message);
        }
    }
}
