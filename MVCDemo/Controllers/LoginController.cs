using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCDemo.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        AdminManager manager = new AdminManager(new EFAdminDAL());
        WriterManager writerManager = new WriterManager(new EFWriterDAL());
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

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            var user = writerManager.Login(p);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Email, false);
                Session["Username"] = user.Email;

                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}