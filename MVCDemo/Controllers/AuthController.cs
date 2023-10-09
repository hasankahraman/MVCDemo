using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        // GET: Auth
        AdminManager am = new AdminManager(new EFAdminDAL());
        public ActionResult Index()
        {
            var admins = am.GetAll();
            return View(admins);
        }
    }
}