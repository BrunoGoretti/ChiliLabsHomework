using ChiliLabsHomework.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChiliLabsHomework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Registration")]
        public async Task<ActionResult> Registration(string identifier, string password)
        {
            var registration = await _userService.Registration(identifier, password);
            return Ok(registration);
        }
    }
}
