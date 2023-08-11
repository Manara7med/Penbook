using Microsoft.AspNetCore.Mvc;
using PenBook.Models.Domain;
using PenBook.Repository.Abstract;

namespace PenBook.Controllers
{
        public class PublisherController : Controller
        {
            private readonly IPublisherService service;

            public PublisherController(IPublisherService service)
            {
                this.service = service;
            }
             public IActionResult Details(int id)
             {
            var Publisher = service.FindById(id);
            return View(Publisher);
             }
        public IActionResult Add()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Add(Publisher model)
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var result = service.Add(model);
                if (result)
                {
                    TempData["msg"] = "Added Successfully";
                    return RedirectToAction(nameof(Add));
                }
                TempData["msg"] = "Error has occured on server side";
                return View(model);
            }
            public IActionResult Update(int id)
            {
                var record = service.FindById(id);
                return View(record);
            }
            [HttpPost]
            public IActionResult Update(Publisher model)
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var result = service.Update(model);
                if (result)
                {
                    return RedirectToAction("GetAll");
                }
                TempData["msg"] = "Error has occured on server side";
                return View(model);
            }
            public IActionResult Delete(int id)
            {
                var result = service.Delete(id);
                return RedirectToAction("GetAll");
            }
            public IActionResult GetAll()
            {
                var data = service.GetAll();
                return View(data);
            }
        }
}
