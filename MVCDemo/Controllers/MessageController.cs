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
    public class MessageController : Controller
    {
        MessageManager manager = new MessageManager(new EFMessageDAL());
        public ActionResult Inbox()
        {
            var messages = manager.GetAll();
            return View(messages);
        }
    }
}