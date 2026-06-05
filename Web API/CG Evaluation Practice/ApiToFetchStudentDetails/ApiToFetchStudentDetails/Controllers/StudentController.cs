using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ApiToFetchStudentDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Place { get; set; } = string.Empty;
            public int M1 { get; set; }
            public int M2 { get; set; }
            public int M3 { get; set; }
        }
        private static List<Student> std = new List<Student>
        {
            new Student{Id=1,Name="Srikaran",Place="Hyderabad",M1=90,M2=80,M3=70},
            new Student{Id=2,Name="Pavan",Place="Bangalore",M1=85,M2=75,M3=65},
            new Student{Id=3,Name="Anjali",Place="Chennai",M1=92,M2=82,M3=72},
            new Student{Id=4,Name="Aditya",Place="Mumbai",M1=88,M2=78,M3=68}
        };
        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(std);
        }
        [HttpGet("{id}")]
        public IActionResult getStdById(int id)
        {
            var s = std.FirstOrDefault(x => x.Id == id);
            return Ok(s);
        }
        [HttpPost]
        public IActionResult AddStudent([FromBody] Student stu)
        {
            if (stu == null)
            {
                return BadRequest("Invalid student data");
            }
            std.Add(stu);
            return Ok(std);
        }
        [HttpPut("{id}")]
        public IActionResult update(int id,Student updated)
        {
            var s = std.FirstOrDefault(x => x.Id == id);
            if (s == null) return NotFound();
            s.Name = updated.Name;
            s.Place = updated.Place;
            s.M1 = updated.M1;
            return Ok(s);
        }
        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            var s = std.FirstOrDefault(x => x.Id == id);
            if (s == null) return NotFound();
            std.Remove(s);
            return Ok("deleted!!");
        }
        [HttpGet]
        public IActionResult marksGreaterThan250()
        {
            var res = std.Where(x => (x.M1 + x.M2 + x.M3) > 250).ToList();
            return Ok(res);
        }
        [HttpGet]
        public IActionResult SortedMarks()
        {
            var res=std.OrderByDescending
        }
    }
}
