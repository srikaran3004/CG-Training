using Microsoft.AspNetCore.Mvc;
using StudentDTO.Models;
using StudentDTO.DTO;

namespace StudentDTO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    { 
        private static List<Student> std = new List<Student>();

        [HttpPost]
        public IActionResult CreateStudent(CreateRequestDTO request)
        {
            Student student = new Student
            {
                Id = std.Count + 1,
                Name = request.Name,
                Age = request.Age
            };
            std.Add(student);
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, UpdateRequestDTO request)
        {
            var student = std.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound("Student not found");

            student.M1 = request.M1;
            student.M2 = request.M2;
            student.Total = request.M1 + request.M2;
            student.Grade = student.Total switch
            {
                >= 180 => "A",
                >= 150 => "B",
                >= 100 => "C",
                _ => "F"
            };
            return Ok(student);
        }

        [HttpGet("{id}")]
        public IActionResult GetResult(int id)
        {
            var student = std.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound("Student not found");

            var result = new GetResultDTO
            {
                Id = student.Id,
                Name = student.Name,
                M1 = student.M1,
                M2 = student.M2,
                Total = student.Total,
                Grade = student.Grade
            };
            return Ok(result);
        }
    }
}
