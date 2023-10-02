using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
    }
}