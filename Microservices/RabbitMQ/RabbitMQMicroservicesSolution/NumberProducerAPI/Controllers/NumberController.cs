using Microsoft.AspNetCore.Mvc;
using NumberProducerAPI.Services;

namespace NumberProducerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NumberController : ControllerBase
    {
        private readonly RabbitMQRPCClient rpcClient;

        public NumberController(RabbitMQRPCClient rpcClient)
        {
            this.rpcClient = rpcClient;
        }

        [HttpPost("square")]
        public async Task<IActionResult> GetSquare(int number)
        {
            var response = await rpcClient.CallAsync("square_queue", number.ToString(), HttpContext.RequestAborted);
            return Ok($"Square Result: {response}");
        }

        [HttpPost("cube")]
        public async Task<IActionResult> GetCube(int number)
        {
            var response = await rpcClient.CallAsync("cube_queue", number.ToString(), HttpContext.RequestAborted);
            return Ok($"Cube Result: {response}");
        }
    }
}