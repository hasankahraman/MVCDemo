using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        MessageManager manager = new MessageManager(new EFMessageDAL());
        public ActionResult Inbox()
        {
            var messages = manager.GetAllInbox();
            return View(messages);
        }
        public ActionResult Sentbox()
        {
            var messages = manager.GetAllSentbox();
            return View(messages);
        }
        [HttpGet]
        public ActionResult AddMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMessage(Message message)
        {
            MessageValidator validator = new MessageValidator();
            FluentValidation.Results.ValidationResult result = validator.Validate(message);

            if (result.IsValid)
            {
                message.SenderMail = "admin@gmail.com";
                message.Status = true;
                message.CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());
                manager.Add(message);
                return RedirectToAction("Sentbox");
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

        public ActionResult GetMessageDetails(int id)
        {
            var messages = manager.GetById(id);
            return View(messages);
        }

    }
}