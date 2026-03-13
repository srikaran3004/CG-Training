using Microsoft.AspNetCore.Mvc;

namespace RoutingPractice.Controllers
{
    [ApiController]

    // CASE 1: Controller + Action in URL → api/student/getStudent
    [Route("api/[controller]/[action]")]

    // CASE 2: Only Controller in URL → api/student
    // [Route("api/[controller]")]

    // CASE 3: Custom route without controller name → api/mystudent
    // [Route("api/mystudent")]

    // CASE 4: Completely custom base route → api/v1/studentdata
    // [Route("api/v1/studentdata")]

    public class StudentController : Controller
    {

        // CASE 5: Default action routing → api/student/getStudent
        [HttpGet]
        public string getStudent()
        {
            return $"Student Details retrieved at {DateTime.Now}";
        }

        // CASE 6: Route parameter in URL → api/student/getStudentById/10
        [HttpGet("{id}")]
        public string getStudentById(int id)
        {
            return $"Student Details of {id} are fetched";
        }

        // CASE 7: Custom route name for action → api/student/name/10
        // [HttpGet("name/{id}")]
        public string getStudentName(int id)
        {
            return $"Student Name of {id} is fetched";
        }

        // CASE 8: Optional parameter → api/student/getStudentCourse OR api/student/getStudentCourse/101
        // [HttpGet("getStudentCourse/{id?}")]
        // public string getStudentCourse(int? id)
        // {
        //     return $"Course details for student {id}";
        // }

        // CASE 9: Route without action name → api/student/10
        // [HttpGet("{id}")]
        // public string Get(int id)
        // {
        //     return $"Student {id} fetched without action name in URL";
        // }

        // CASE 10: Completely custom endpoint → api/student/details/5
        // [HttpGet("details/{id}")]
        // public string studentDetails(int id)
        // {
        //     return $"Custom route student details {id}";
        // }

        // CASE 11: Route without controller and action → api/allstudents
        // [HttpGet("/api/allstudents")]
        // public string getAllStudents()
        // {
        //     return "All students list";
        // }

        // CASE 12: Query string example → api/student/search?id=10
        // [HttpGet("search")]
        // public string searchStudent(int id)
        // {
        //     return $"Search student with id {id}";
        // }

        // CASE 13: Multiple route patterns for same action
        // [HttpGet("info/{id}")]
        // [HttpGet("profile/{id}")]
        // public string studentInfo(int id)
        // {
        //     return $"Student info for {id}";
        // }

        // CASE 14: Route constraint example → api/student/15 (only integers allowed)
        // [HttpGet("constraint/{id:int}")]
        // public string studentConstraint(int id)
        // {
        //     return $"Student with constrained id {id}";
        // }

    }
}