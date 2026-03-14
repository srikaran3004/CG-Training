using Microsoft.AspNetCore.Mvc;
using SimpleWebAPI.Models;

namespace SimpleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetStudents()
        {
            var Students = new List<Student>
            {
                new Student { Id = 1, Name = "Pavan", marks = 95 },
                new Student { Id = 2, Name = "Srikaran", marks = 92 },
                new Student { Id = 3, Name = "Kishan", marks = 98 }
            };
            _logger.LogInformation("GetStudents method called");
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
            _logger.LogInformation("OddNumbers method called");
            return Ok(odd);
        }
    }
}