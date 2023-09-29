using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager manager = new HeadingManager(new EFHeadingDAL());

        // GET: WriterPanel
        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult WritersHeading()
        {
            int writerId = 1;
            var headings = manager.GetAllByWriter(writerId);
            return View(headings);
        }
    }
}