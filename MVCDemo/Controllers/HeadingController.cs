using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager manager = new HeadingManager(new EFHeadingDAL());
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDAL());
        WriterManager writerManager = new WriterManager(new EFWriterDAL());
        public ActionResult Index()
        {
            var headings = manager.GetAll();
            return View(headings);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> categories = (from x in categoryManager.GetAll()
                                               select new SelectListItem
                                               { 
                                                   Text = x.Name,
                                                   Value = x.Id.ToString()
                                               }).ToList();
            ViewBag.Categories = categories;

            List<SelectListItem> writers = (from x in writerManager.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name + " " + x.Surname,
                                                   Value = x.Id.ToString()
                                               }).ToList();
            ViewBag.Writers = writers;

            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            HeadingValidator validator = new HeadingValidator();
            FluentValidation.Results.ValidationResult result = validator.Validate(heading);

            heading.CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());

            if (result.IsValid)
            {
                heading.Status = true;
                manager.Add(heading);
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

        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            var heading = manager.GetById(id);
            List<SelectListItem> categories = (from x in categoryManager.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.Id.ToString()
                                               }).ToList();
            ViewBag.Categories = categories;

            List<SelectListItem> writers = (from x in writerManager.GetAll()
                                            select new SelectListItem
                                            {
                                                Text = x.Name + " " + x.Surname,
                                                Value = x.Id.ToString()
                                            }).ToList();
            ViewBag.Writers = writers;

            return View(heading);
        }
        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            HeadingValidator validator = new HeadingValidator();
            FluentValidation.Results.ValidationResult result = validator.Validate(heading);

            if (result.IsValid)
            {
                heading.CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());
                manager.Update(heading);
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

        public ActionResult DeleteHeading(int id)
        {
            var headingToDelete = manager.GetById(id);
            headingToDelete.Status = false;
            manager.Delete(headingToDelete);
            return RedirectToAction("Index");
        }
    }
}