using CustomFiltersCustomMiddleware_Authorization.Models;
using CustomFiltersCustomMiddleware_Authorization.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomFiltersCustomMiddleware_Authorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student>()
        {
            new Student{Id=1, Name="Srikaran", Age=22, Course="ComputerScience"},
            new Student{Id=2, Name="Pavan", Age=21, Course="Datascience"}
        };

        // USER + ADMIN
        [HttpGet]
        public ActionResult GetStudents()
        {
            return Ok(students);
        }

        // USER + ADMIN
        [HttpGet("{id}")]
        public ActionResult GetStudent(int id)
        {
            var s = students.FirstOrDefault(s => s.Id == id);
            if (s == null) return NotFound();
            return Ok(s);
        }

        // ADMIN ONLY
        [HttpPost("add")]
        [RoleAuthorize("Admin")]
        public ActionResult AddStudent([FromBody] List<Student> s)
        {
            students.AddRange(s);
            return Ok(s);
        }

        // ADMIN ONLY
        [HttpDelete("delete/{id}")]
        [RoleAuthorize("Admin")]
        public ActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);
            if (student == null) return NotFound();
            students.Remove(student);
            return Ok("Student Deleted");
        }
    }
}