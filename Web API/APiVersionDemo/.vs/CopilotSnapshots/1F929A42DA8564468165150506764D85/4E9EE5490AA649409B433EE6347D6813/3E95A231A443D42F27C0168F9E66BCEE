using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APiVersionDemo.Controllers
{
    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/student")]
    public class StudentV1Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(new
            {
                Version = "V1",
                Students = new string[] { "Srikaran", "Pavan", "Vamsi" }
            });
        }
    }

    [ApiController]
    [ApiVersion(2.0)]
    [Route("api/v{version:apiVersion}/student")]
    public class StudentV2Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(new
            {
                Version = "V2",
                Students = new[]
                {
                    new { Id = 1, Name = "Srikaran", Department = "CSE" },
                    new { Id = 2, Name = "Pavan", Department = "ECE" },
                    new { Id = 3, Name = "Vamsi", Department = "IT" }
                }
            });
        }
    }
}
