using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class AboutController : Controller
    {
        AboutManager manager = new AboutManager(new EFAboutDAL());
        public ActionResult Index()
        {
            var abouts = manager.GetAll();
            return View(abouts);
        }
    }
}