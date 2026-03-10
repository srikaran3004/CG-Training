using Microsoft.AspNetCore.Mvc;
using SimpleWebAPI.Models;

namespace SimpleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            var Students = new List<Student>
            {
                new Student { Id = 1, Name = "Pavan", marks = 95 },
                new Student { Id = 2, Name = "Srikaran", marks = 92 },
                new Student { Id = 3, Name = "Kishan", marks = 98 }
            };

            return Ok(Students);
        }
        [HttpGet("oddnumbers")]
        public IActionResult OddNumbers()
        {
            List<int> odd = new List<int>();

            for (int i = 1; i <= 100; i++)
            {
                if (i % 2 != 0)
                {
                    odd.Add(i);
                }
            }

            return Ok(odd);
        }
    }
}