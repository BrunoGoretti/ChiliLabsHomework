using ChiliLabsHomework.Models;
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
        public async Task<ActionResult> Registration([FromBody] RegistrationRequestModel request)
        {
            var registration = _userService.Registration(request);
            return Ok(registration);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginRequestModel request)
        {
            var login = _userService.Login(request);
            return Ok(login);
        }
    }
}
