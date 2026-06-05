using Microsoft.AspNetCore.Mvc;
using ConsumerAPI.Models;
using System.Text;
using System.Text.Json;

namespace ConsumerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public OrderController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> SendOrderToProducer([FromBody] Order order)
        {
            var client = _httpClientFactory.CreateClient();

            var baseUrl = _configuration["ProducerApi:BaseUrl"];

            var json = JsonSerializer.Serialize(order);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{baseUrl}/api/order", content);

            var result = await response.Content.ReadAsStringAsync();

            return Ok(result);
        }
    }
}