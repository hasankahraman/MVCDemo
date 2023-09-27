using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    [Authorize]
    public class WriterController : Controller
    {
        WriterManager manager = new WriterManager(new EFWriterDAL());
        WriterValidator validator = new WriterValidator();

        public ActionResult Index()
        {
            var writers = manager.GetAll();
            return View(writers);
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            ValidationResult result = validator.Validate(writer);

            if (result.IsValid)
            {
                manager.Add(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult UpdateWriter(int id)
        {
            var writer = manager.GetById(id);

            return View(writer);
        }
        [HttpPost]
        public ActionResult UpdateWriter(Writer writer)
        {
            ValidationResult result = validator.Validate(writer);

            if (result.IsValid)
            {
                manager.Update(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
    }
}