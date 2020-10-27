using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_AssignmentX.Models;

namespace FIT5032_AssignmentX.Controllers
{
    public class HomeController : Controller
    {
        private RatingContainer db = new RatingContainer();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            var total = db.Rates.Count();
            List<Rate> rate1= (from a in db.Rates select a).ToList();
            ViewBag.number = total;
            int totalCount = 0;
            foreach (var r in rate1)
            {
                totalCount += r.RatingLevel;
            }
            int average = totalCount / total;
            ViewBag.average = average;
            return View();
        }
        [HttpPost]
        public ActionResult About(FormCollection post)
        {
            Rate r = new Rate();
            string level = post["input-1"];
            short number;
            bool result = Int16.TryParse(level, out number);
            if (result)
            {
                r.RatingLevel = number;
                db.Rates.Add(r);
                db.SaveChanges();
            }
            return RedirectToAction("About");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Plan()
        {
            ViewBag.Message = "Your plan page.";

            return View();
        }

        [Authorize (Roles ="admin")]
        public ActionResult Manage()
        {
            ViewBag.Message = "Your management page.";

            return View();
        }
    }
}