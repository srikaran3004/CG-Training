using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APiVersionDemo.Controllers
{
    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/course")]
    public class CourseV1Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCourses()
        {
            return Ok(new
            {
                Version = "V1",
                Courses = new string[] { "C#", "ASP.NET Core", "Azure" }
            });
        }
    }

    [ApiController]
    [ApiVersion(2.0)]
    [Route("api/v{version:apiVersion}/course")]
    public class CourseV2Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCourses()
        {
            return Ok(new
            {
                Version = "V2",
                Courses = new[]
                {
                    new { Id = 1, Name = "C#", Instructor = "Srikaran", Duration = "4 Weeks", Credits = 4 },
                    new { Id = 2, Name = "ASP.NET Core", Instructor = "Pavan", Duration = "6 Weeks", Credits = 6 },
                    new { Id = 3, Name = "Azure", Instructor = "Vamsi", Duration = "5 Weeks", Credits = 5 }
                }
            });
        }
    }
}
