using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EFHeadingDAL());
        ContentManager contentManager = new ContentManager(new EFContentDAL());
        public PartialViewResult Index(int id = 0)
        {
            var contents = contentManager.GetContentsByHeading(id);
            return PartialView(contents);
        }

        public ActionResult Headings()
        {
            var headings = headingManager.GetAll();
            return View(headings);
        }
    }
}