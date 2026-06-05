using Microsoft.AspNetCore.Mvc;
using ProducerAPI.Models;

namespace ProducerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {

        [HttpPost]
        public IActionResult ReceiveOrder([FromBody] Order order)
        {
            var result = new
            {
                Message = "Order received successfully",
                OrderId = order.OrderId,
                Product = order.ProductName,
                Quantity = order.Quantity
            };

            return Ok(result);
        }
    }
}