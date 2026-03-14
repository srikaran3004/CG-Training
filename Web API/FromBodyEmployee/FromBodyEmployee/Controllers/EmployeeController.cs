using Microsoft.AspNetCore.Mvc;

namespace FromBodyEmployee.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        [HttpPost("add")]
        public IActionResult AddEmployee([FromBody] List<Employee> employees)
        {
            //if (employees is null || employees.Count == 0)
            //{
            //    return BadRequest("Employee list is required.");
            //}

            Employee.Employees.AddRange(employees);
            return Ok(employees);
        }

        [HttpGet("all")]
        public ActionResult<List<Employee>> GetAllEmployees()
        {
            return Ok(Employee.Employees);
        }

        [HttpGet("total-salary")]
        public ActionResult<double> GetTotalSalaryOfAll()
        {
            return Ok(Employee.Employees.Sum(e => e.Salary));
        }

    }
}
