using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager manager = new ContentManager(new EFContentDAL());
        WriterManager writerManager = new WriterManager(new EFWriterDAL());

        public ActionResult MyContent(string writerEmail)
        {
            writerEmail = (string)Session["Username"];
            var writerId = writerManager.GetWriterIdByEmail(writerEmail);

            var contentsByHeadingId = manager.GetContentsByWriter(writerId);

            return View(contentsByHeadingId);
        }
        [HttpGet]
        public ActionResult AddContent(int id) 
        {
            ViewBag.HeadingId = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            content.CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());
            string writerEmail = (string)Session["Username"];
            var writerId = writerManager.GetWriterIdByEmail(writerEmail);
            content.WriterId = writerId;
            content.Status = true;
            manager.Add(content);
            return RedirectToAction("MyContent");
        }
    }
}