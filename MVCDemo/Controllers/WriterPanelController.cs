using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System;
using System.Web.Mvc;
using System.Linq;


namespace MVCDemo.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager manager = new HeadingManager(new EFHeadingDAL());
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDAL());
        WriterManager writerManager = new WriterManager(new EFWriterDAL());

        // GET: WriterPanel
        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult WritersHeading()
        {
            int writerId = 1;
            var headings = manager.GetAllByWriter(writerId);
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
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            HeadingValidator validator = new HeadingValidator();
            FluentValidation.Results.ValidationResult result = validator.Validate(heading);

            heading.CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = 1;
            heading.Status = true;

            if (result.IsValid)
            {
                manager.Add(heading);
                return RedirectToAction("WritersHeading");
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

            return View(heading);
        }
        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            HeadingValidator validator = new HeadingValidator();
            FluentValidation.Results.ValidationResult result = validator.Validate(heading);

            if (result.IsValid)
            {
                manager.Update(heading);
                return RedirectToAction("WritersHeading","WriterPanel");
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