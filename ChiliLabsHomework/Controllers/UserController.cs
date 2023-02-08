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
        public async Task<ActionResult> Registration(string nickname, string password)
        {
            var registration = _userService.Registration(nickname, password);
            return Ok(registration);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(string nickname, string password)
        {
            var login = _userService.Login(nickname, password);
            return Ok(login);
        }
    }
}
