using Microsoft.AspNetCore.Mvc;

namespace AddThreeNumbers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SumController : ControllerBase
    {
        [HttpGet]
        public ActionResult<int> GetSum(int a, int b, int c)
        {
            return a + b + c;
        }
    }
}
