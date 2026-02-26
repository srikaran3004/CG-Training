using Microsoft.AspNetCore.Mvc;
using CRUDApplicationMVC.DAL;
using CRUDApplicationMVC.Models;

namespace CRUDApplicationMVC.Controllers
{
    public class PersonController : Controller
    {
        PersonDAL dal = new PersonDAL();

        public IActionResult Index()
        {
            return View(dal.GetAllPersons());
        }

        [HttpPost]
        public IActionResult Insert(PersonModel p)
        {
            if (ModelState.IsValid)
            {
                dal.AddPerson(p);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(PersonModel p)
        {
            if (ModelState.IsValid)
            {
                dal.UpdatePerson(p);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            dal.DeletePerson(id);
            return RedirectToAction("Index");
        }

    }
}