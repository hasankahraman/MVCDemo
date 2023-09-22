using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class ContactController : Controller
    {
        ContactManager manager = new ContactManager(new EFContactDAL());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetContactDetails(int id)
        {
            var contact = manager.GetById(id);
            return View(contact);
        }
        public PartialViewResult PVMessageListMenu()
        {
            return PartialView();
        }
    }
}