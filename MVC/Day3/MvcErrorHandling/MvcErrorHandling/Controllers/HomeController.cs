using Microsoft.AspNetCore.Mvc;
using MvcErrorHandling.Models;
using System.Diagnostics;

namespace MvcErrorHandling.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
        public IActionResult TestError() {
            int x = 10;
            int y = 0;
            int result = x / y;
            return Content($"The result of {x} divided by {y} is: {result}");
        }
        public IActionResult Error()
        {
            return View();
        }
        public IActionResult Send()
        {
            TempData["Message"] = "Hello from Home Controller";
            return RedirectToAction("Receive","Student");
        }
        public IActionResult Sum()
        {
            TempData["a"] = 10;
            TempData["b"] = 20;
            return RedirectToAction("Add", "Student"); // Receiving Method, Controller Name
            //We need to call /home/send it redirects to /student/sum
        }
    }
}
