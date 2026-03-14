using Microsoft.AspNetCore.Mvc;
using DbPerInstanceDemo.Data;
using DbPerInstanceDemo.Models;

namespace DbPerInstanceDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public IActionResult AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return Ok(student);
        }

        [HttpGet("all")]
        public IActionResult GetStudents()
        {
            return Ok(_context.Students.ToList());
        }
    }
}