using Microsoft.AspNetCore.Mvc;

namespace SimpleIISAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DemoController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello World - IIS Demo";
        }
    }
}