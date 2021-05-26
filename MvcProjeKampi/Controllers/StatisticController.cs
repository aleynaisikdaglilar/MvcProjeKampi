using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        public ActionResult Index()
        {

            using (Context context = new Context())
            {
                ViewBag.categoryCounter = context.Categories.Count();
                ViewBag.softwareCounter = context.Headings.Where(x => x.CategoryID == 14).Count();
                ViewBag.writerCounter = context.Writers.Where(x => x.WriterName.Contains("a")).Count();
                ViewBag.maxHeadingCateName = context.Categories.Where(u => u.CategoryID == context.Headings.GroupBy(x => x.CategoryID).OrderByDescending(x => x.Count())
                 .Select(x => x.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
                ViewBag.diffCategoryTF = context.Categories.Count(x => x.CategoryStatus == true) - context.Categories.Count(x => x.CategoryStatus == false);
                return View();
            }
        }
    }
}