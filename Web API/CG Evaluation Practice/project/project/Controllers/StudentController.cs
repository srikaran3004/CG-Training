using Microsoft.AspNetCore.Mvc;
using MyWebApi.Services;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var name = _userService.GetName();
            return Ok(name);
        }
    }
}