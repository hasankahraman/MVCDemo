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
    [Authorize(Roles= "B")]
    public class AdminCategoryController : Controller
    {

        CategoryManager cm = new CategoryManager(new EFCategoryDAL());

        public ActionResult Index()
        {
            var categories = cm.GetAll();
            return View(categories);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator validator = new CategoryValidator();
            FluentValidation.Results.ValidationResult result = validator.Validate(category);

            if (result.IsValid)
            {
                cm.Add(category);
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
        public ActionResult DeleteCategory(int id)
        {
            var category = cm.GetById(id);

            cm.Delete(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var category = cm.GetById(id);

            return View(category);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            CategoryValidator validator = new CategoryValidator();
            FluentValidation.Results.ValidationResult result = validator.Validate(category);

            if (result.IsValid)
            {
                cm.Update(category);
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