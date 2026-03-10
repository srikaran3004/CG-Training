using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/students")]
public class StudentController : ControllerBase
{
    [HttpGet]
    public IActionResult GetStudents()
    {
        var students = new List<string>
        {
            "Srikaran",
            "Pavan",
            "Vamsi"
        };

        return Ok(students);
    }
}