using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIJWT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(new List<string>
            {
                "Laptop",
                "Mobile",
                "Tablet"
            });
        }

    }
}