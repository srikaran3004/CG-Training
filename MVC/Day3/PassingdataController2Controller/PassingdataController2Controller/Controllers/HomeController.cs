using Microsoft.AspNetCore.Mvc;
using PassingdataController2Controller.Models;
using System.Diagnostics;

namespace PassingdataController2Controller.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Square()
        {
            int num = 7;
            return Redirect("/Student/Square/" + num);
        }
        public IActionResult SendNumber()
        {
            TempData["num"] = 8;
            return RedirectToAction("CalculateSquare","Student");
        }
        public IActionResult MyNamePrint(string name, string college)
        {
            ViewBag.MyName = name;
            ViewBag.CollegeName = college;
            return View();
        }
    }
}
