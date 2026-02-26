using Microsoft.AspNetCore.Mvc;

namespace PassingdataController2Controller.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Square(int id)
        {
            int result = id * id;
            return Content($"Square of {id} is: {result}");
        }
        public IActionResult CalculateSquare()
        {
            int n = TempData["num"] as int? ?? 0;
            int result = n * n;
            return Content($"Square of {n} is: {result}");
        }
    }
}
