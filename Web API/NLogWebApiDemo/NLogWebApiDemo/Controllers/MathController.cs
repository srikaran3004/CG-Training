using Microsoft.AspNetCore.Mvc;

namespace NLogWebApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MathController : ControllerBase
    {
        private readonly ILogger<MathController> _logger;

        public MathController(ILogger<MathController> logger)
        {                       
            _logger = logger;
        }

        [HttpGet("add")]
        public IActionResult Add(int a, int b)
        {
            _logger.LogInformation("Add endpoint called with parameters a={A}, b={B}", a, b);

            var result = a + b;

            _logger.LogInformation("Add execution successful. Result={Result}", result);
            return Ok(result);
        }

        [HttpGet("multiply")]
        public IActionResult Multiply(int a, int b)
        {
            _logger.LogInformation("Multiply endpoint called with parameters a={A}, b={B}", a, b);

            var result = a * b;

            _logger.LogInformation("Multiply execution successful. Result={Result}", result);
            return Ok(result);
        }
    }
}