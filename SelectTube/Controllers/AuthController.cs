using Microsoft.AspNetCore.Mvc;
using SelectTube.Models;

namespace SelectTube.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            if (user.Username == "demo" && user.Password == "demo123")
            {
                return Ok("Login successful");
            }
            else
            {
                return Unauthorized("Invalid credentials");
            }
        }
    }
}