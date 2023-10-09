using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MVCDemo.Controllers.ChartController;

namespace MVCDemo.Controllers
{
    [AllowAnonymous]
    public class ChartController : Controller
    {
        // GET: Chart
        CategoryManager cm = new CategoryManager(new EFCategoryDAL());
        HeadingManager hm = new HeadingManager(new EFHeadingDAL());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Chart()
        {
            return Json(CategoriesList(), JsonRequestBehavior.AllowGet);
        }

        public class Categories {

            public string Name { get; set; }
            public int Count { get; set; }
        }

        public List<Categories> CategoriesList()
        {
            List<Categories> categories = new List<Categories>();
            List<Heading> headings = new List<Heading>();
            headings = hm.GetAll();

            foreach (var item in cm.GetAll().ToList())
            {
                int counthead = 0;

                foreach (var item2 in headings)
                {
                    if (item2.CategoryId == item.Id)
                    {
                        counthead += 1;
                    }
                }
                categories.Add(new Categories { Name = item.Name, Count = counthead });
            }
            categories.Add(new Categories { Name = "Yazılım", Count = 5 });
            categories.Add(new Categories { Name = "Seyahat", Count = 8 });
            categories.Add(new Categories { Name = "Teknoloji", Count = 4 });
            categories.Add(new Categories { Name = "Spor", Count = 3 });
            categories.Add(new Categories { Name = "Edebiyat", Count = 2 });

            return categories;
        }

        public ActionResult Export()
        {
            var headings = hm.GetAll();
            return View(headings);
        }

    }
}