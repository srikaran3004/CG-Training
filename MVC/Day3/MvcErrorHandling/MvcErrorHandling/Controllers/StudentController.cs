using Microsoft.AspNetCore.Mvc;

namespace MvcErrorHandling.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Receive()
        {
            var message = TempData["Message"] as string;
            return Content($"Received message: {message}");
        }
        public IActionResult Add() {
            int a = TempData["a"] as int? ?? 0;
            int b = TempData["b"] as int? ?? 0;
            int c = a + b;
            return Content($"Sum of two numbers is: {c}");
        }
    }
}
