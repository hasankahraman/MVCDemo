using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCDemo.Controllers
{
    public class LoginController : Controller
    {
        AdminManager manager = new AdminManager(new EFAdminDAL());
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var user = manager.Login(p);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                Session["Username"] = user.Username;

                return RedirectToAction("Inbox","Message");
            }
            else
            {
                return RedirectToAction("Index");
            }


        }
    }
}