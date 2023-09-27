using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    [Authorize]
    public class GalleryController : Controller
    {
        ImageFileManager manager = new ImageFileManager(new EFImageFileDAL());
        public ActionResult Index()
        {
            var gallery = manager.GetAll();
            return View(gallery);
        }
    }
}