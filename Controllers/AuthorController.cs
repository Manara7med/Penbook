using Microsoft.AspNetCore.Mvc;
using PenBook.Models.Domain;
using PenBook.Repository.Abstract;

namespace PenBook.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService Service;

        public AuthorController( IAuthorService Service)
        {
            this.Service = Service;
        }
        public IActionResult Details(int id)
        {
            var Author = Service.FindById(id);
            return View(Author);
        }

        public IActionResult Add()
        {
           return View();
        }
       
        [HttpPost]
        public IActionResult Add(Author model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = Service.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Error has occured on server side";
            return View(model);
        }
     
        public IActionResult Update(int id )
        {
            var record = Service.FindById(id);
            return View(record);
        }
        [HttpPost]
        public IActionResult Update(Author model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = Service.Update(model);
            if (result)
            {
                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Error has occured on server side";
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var result = Service.Delete(id);
            return RedirectToAction("GetAll");
        }
        public IActionResult GetAll()
        {
            var data = Service.GetAll();
            return View(data);
        }

    }
}
