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
        public async Task<ActionResult> Registration([FromBody] RegistrationRequestModel login)
        {
            var registration = _userService.Registration(login);
            return Ok(registration);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginRequestModel login)
        {
            var result = _userService.Login(login);
            return Ok(result);
        }
    }
}
