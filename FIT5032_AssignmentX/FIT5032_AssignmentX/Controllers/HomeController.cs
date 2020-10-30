using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using FIT5032_AssignmentX.Models;
using Newtonsoft.Json.Linq;

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

        public ActionResult News()
        {
            var url = "http://newsapi.org/v2/top-headlines?" +
             "country=au&" +
             "category=sport&" +
             "apiKey=a6c81ed03d6b4f6bb3275b98f17ed3a7";
            var json = new WebClient().DownloadString(url);
            List<string> title = new List<string>();
            List<string> link = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                title.Add(Encoding.UTF8.GetString(Encoding.Default.GetBytes(JObject.Parse(json)["articles"][i]["title"].ToString())));
                link.Add(JObject.Parse(json)["articles"][i]["url"].ToString());
            }
            ViewBag.title0 = title[0];
            ViewBag.link0 = link[0];
            ViewBag.title1 = title[1];
            ViewBag.link1 = link[1];
            ViewBag.title2 = title[2];
            ViewBag.link2 = link[2];
            ViewBag.title3 = title[3];
            ViewBag.link3 = link[3];
            ViewBag.title4 = title[4];
            ViewBag.link4 = link[4];

            return View();
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