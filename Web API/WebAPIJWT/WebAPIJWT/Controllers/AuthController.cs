using Microsoft.AspNetCore.Mvc;
using WebAPIJWT.Models;
using WebAPIJWT.Services;

namespace WebAPIJWT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;

        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            if (request.Username == "admin" && request.Password == "123")
            {
                var token = _jwtService.GenerateToken(request.Username);

                return Ok(new LoginResponse
                {
                    Token = token
                });
            }

            return Unauthorized("Invalid Credentials");
        }
    }
}