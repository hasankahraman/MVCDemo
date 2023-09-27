using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        AboutManager manager = new AboutManager(new EFAboutDAL());
        public ActionResult Index()
        {
            var abouts = manager.GetAll();
            return View(abouts);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            AboutValidator validator = new AboutValidator();
            FluentValidation.Results.ValidationResult result = validator.Validate(about);

            if (result.IsValid)
            {
                about.Status = true;
                manager.Add(about);
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

        public PartialViewResult PVAbout()
        {
            return PartialView();
        }
    }
}