using Microsoft.AspNetCore.Mvc;

namespace CalculateStudentMarks.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult CalculateMarks(int M1, int M2, int M3)
        {
            double average = (M1 + M2 + M3) / 3.0;
            return View(average);
        }
    }
}