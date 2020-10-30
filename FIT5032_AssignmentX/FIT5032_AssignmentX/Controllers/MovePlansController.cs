using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_AssignmentX.Models;
using Microsoft.AspNet.Identity;
using PagedList;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Security;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FIT5032_AssignmentX.Controllers
{
    [Authorize]
    [ValidateInput(false)]
    public class MovePlansController : Controller
    {
        private MovesContainer db = new MovesContainer();
    // GET: MovePlans
    public ActionResult Index()
        {
            var UserID = User.Identity.GetUserId();
            var moves = from s in db.MovePlans where s.UserID == UserID select s;
            if (User.IsInRole("admin"))
            { 
                moves = from s in db.MovePlans select s; 
            }
            return View(db.MovePlans.ToList());
        }

        // GET: MovePlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovePlans movePlans = db.MovePlans.Find(id);
            if (User.Identity.GetUserId() != movePlans.UserID && !User.IsInRole("admin"))
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View("Disable");
            }
            if (movePlans == null)
            {
                return HttpNotFound();
            }
            return View(movePlans);
        }

        // GET: MovePlans/Create
        //public ActionResult Create()
        //{
        //    var lstskill = (from a in db.Movements orderby a.MovementName select a).ToList();
        //    ViewBag.move = ToSelectList(lstskill);
        //    ViewBag.move = new SelectList(db.Movements,"MovementName");
        //    return View();
        //}

        public ActionResult Create(String date)
        {
            var lstskill = (from a in db.Movements orderby a.MovementName select a).ToList();
            var eachPlan = (from a in db.MovePlans select a).ToList();
            ViewBag.move = ToSelectList(lstskill);
            if (null == date)
                return RedirectToAction("Index");
            MovePlans e = new MovePlans();
            DateTime convertedDate = DateTime.Parse(date);
            bool flag = true;
            foreach (var i in eachPlan)
            {
                if (i.Date.Equals(convertedDate))
                {
                    flag = false;
                    break;
                }
                else
                    flag = true;
            }
            e.Date = convertedDate;
            if (flag)
                return View(e);
            else
                return RedirectToAction("Index");
        }

        public SelectList ToSelectList(List<Movements> lstskill)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (Movements item in lstskill)
            {
                list.Add(new SelectListItem()
                {
                    Text = item.MovementName,
                    Value = item.MovementName
                });
            }

            return new SelectList(list, "Value", "Text");
        }
    

    // POST: MovePlans/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlanId,MoveName,Time,Round,Date,UserID")] MovePlans movePlans)
        {
            var lstskill = (from a in db.Movements orderby a.MovementName select a).ToList();
            ViewBag.move = ToSelectList(lstskill);
            if (ModelState.IsValid)
            {
                movePlans.UserID = User.Identity.GetUserId();
                db.MovePlans.Add(movePlans);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movePlans);
        }

        // GET: MovePlans/Edit/5
        public ActionResult Edit(int? id)
        {
            var lstskill = (from a in db.Movements orderby a.MovementName select a).ToList();
            ViewBag.move = ToSelectList(lstskill);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovePlans movePlans = db.MovePlans.Find(id);
            if (User.Identity.GetUserId() != movePlans.UserID && !User.IsInRole("admin"))
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View("Disable");
            }
            if (movePlans == null)
            {
                return HttpNotFound();
            }
            return View(movePlans);
        }

        // POST: MovePlans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlanId,MoveName,Time,Round,Date,UserID")] MovePlans movePlans)
        {
            var lstskill = (from a in db.Movements orderby a.MovementName select a).ToList();
            ViewBag.move = ToSelectList(lstskill);
            if (ModelState.IsValid)
            {
                db.Entry(movePlans).State = EntityState.Modified;
                movePlans.UserID = User.Identity.GetUserId();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movePlans);
        }

        // GET: MovePlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovePlans movePlans = db.MovePlans.Find(id);
            if (User.Identity.GetUserId() != movePlans.UserID && !User.IsInRole("admin"))
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View("Disable");
            }
            if (movePlans == null)
            {
                return HttpNotFound();
            }
            return View(movePlans);
        }

        // POST: MovePlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovePlans movePlans = db.MovePlans.Find(id);
            if (User.Identity.GetUserId() != movePlans.UserID && !User.IsInRole("admin"))
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View("Disable");
            }
            db.MovePlans.Remove(movePlans);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Report()
        {
            var UserID = User.Identity.GetUserId();
            var name1 = (from a in db.MovePlans orderby a.MoveName select a).ToList();
            List<MovePlans> name2 = (from a in db.MovePlans orderby a.MoveName where a.UserID == UserID select a).ToList();
            if (User.IsInRole("admin"))
            { 
                name2 = (from a in db.MovePlans orderby a.MoveName select a).ToList();
             }
            List<String> string2 = new List<String>();
            List<int> string3 = new List<int>();
            string3.Add(0);
            var index = -1;
            foreach (var a in name2)
            {
                if (!string2.Contains(a.MoveName.ToString()))
                {
                    string2.Add(a.MoveName.ToString());
                    index++;
                    string3.Add(0);
                    string3[index] += a.Round * a.Time;
                }
                else
                {
                    string3[index] += a.Round * a.Time;
                }
            }
            ViewBag.list = string2;
            ViewBag.round = string3;
            return View();
        }


        public ActionResult SendEmail()
        {
            return View();
        }

        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            var db2 = new ApplicationDbContext();
            IdentityUser user = db2.Users.FirstOrDefault<IdentityUser>(u => u.UserName == User.Identity.Name);
            string email = null;
            if (User.Identity.IsAuthenticated)
                email = user.Email;
            var name = file.ToString();
            var fileName = file.FileName;
            var filePath = Server.MapPath(string.Format("~/{0}", "File"));
            file.SaveAs(Path.Combine(filePath, fileName));
            SendEmail sd = new SendEmail();
            sd.Send(fileName, filePath, email);
            return RedirectToAction("SendEmail", "MovePlans");
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
