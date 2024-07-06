using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest register)
        {
            return Ok(register);
        }
        [HttpPost("login")]
        public IActionResult Login(LoginRequest register)
        {
            return Ok(register);
        }
    }
}
