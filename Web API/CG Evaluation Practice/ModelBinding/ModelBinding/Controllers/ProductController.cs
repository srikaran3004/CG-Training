using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModelBinding.Controllers
{
    public class Product
    {
        public int ProdId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult getProdId([FromRoute]int id)
        {
            return Ok($"Product Id found!!");
        }
        [HttpPost]
        public IActionResult getDetails([FromBody] Product p)
        {
            return Ok($"Product's Id is {p.ProdId} , Product's Name is {p.Name} and Price is {p.Price}");
        }
    }
}
