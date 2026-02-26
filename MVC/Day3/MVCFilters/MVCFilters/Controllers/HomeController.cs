using Microsoft.AspNetCore.Mvc;
using MVCFilters.Filters;

namespace MVCFilters.Controllers
{
    [InputFilter]
    public class HomeController : Controller
    {
        public IActionResult Index(string name)
        {
            return Content("Hello " + name);
        }
    }
}