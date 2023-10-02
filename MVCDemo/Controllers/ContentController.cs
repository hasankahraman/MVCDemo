using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class ContentController : Controller
    {
        ContentManager manager = new ContentManager(new EFContentDAL());
        public ActionResult Index()
        {
            var contents = manager.GetAll();
            return View(contents);
        }
        public ActionResult GetContentsByHeading(int id)
        {
            var contentsByHeadingId = manager.GetContentsByHeading(id);

            return View(contentsByHeadingId);
        }
    }
}