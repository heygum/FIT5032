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

namespace FIT5032_AssignmentX.Controllers
{
    public class RecipePlansController : Controller
    {
        private RecipeContainer db = new RecipeContainer();

        // GET: RecipePlans
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CalorieSortParm = sortOrder == "Calorie" ? "calorie_desc" : "Calorie";
            ViewBag.QuantitySortParm = sortOrder == "Quantity" ? "quantity_desc" : "Quantity";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.UserIDSortParm = sortOrder == "UserID" ? "userid_desc" : "UserID";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var UserID = User.Identity.GetUserId();
            var recipes = from s in db.RecipePlans where s.UserID == UserID select s;
            if (User.IsInRole("admin"))
            {
                recipes = from s in db.RecipePlans select s;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                recipes = recipes.Where(s => s.ReciName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    recipes = recipes.OrderByDescending(s => s.ReciName);
                    break;
                case "Date":
                    recipes = recipes.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    recipes = recipes.OrderByDescending(s => s.Date);
                    break;
                case "Calorie":
                    recipes = recipes.OrderBy(s => s.Calorie);
                    break;
                case "calorie_desc":
                    recipes = recipes.OrderByDescending(s => s.Calorie);
                    break;
                case "Quantity":
                    recipes = recipes.OrderBy(s => s.Quantity);
                    break;
                case "quantity_desc":
                    recipes = recipes.OrderByDescending(s => s.Quantity);
                    break;
                case "UserID":
                    recipes = recipes.OrderBy(s => s.UserID);
                    break;
                case "userid_desc":
                    recipes = recipes.OrderByDescending(s => s.UserID);
                    break;
                default:
                    recipes = recipes.OrderBy(s => s.ReciName);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(recipes.ToPagedList(pageNumber, pageSize));
        }

        // GET: RecipePlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipePlans recipePlans = db.RecipePlans.Find(id);
            if (User.Identity.GetUserId() != recipePlans.UserID && !User.IsInRole("admin"))
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View("Disable");
            }
            if (recipePlans == null)
            {
                return HttpNotFound();
            }
            return View(recipePlans);
        }

        // GET: RecipePlans/Create
        public ActionResult Create()
        {
            var recipes = (from a in db.Recipes orderby a.RecipeName select a).ToList();
            ViewBag.reci = ToSelectList(recipes);
            return View();
        }

        public SelectList ToSelectList(List<Recipes> recipes)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (Recipes item in recipes)
            {
                list.Add(new SelectListItem()
                {
                    Text = item.RecipeName,
                    Value = item.RecipeName
                });
            }

            return new SelectList(list, "Value", "Text");
        }

        // POST: RecipePlans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlanID,ReciName,Calorie,Quantity,Date,UserID")] RecipePlans recipePlans)
        {
            if (ModelState.IsValid)
            {
                recipePlans.UserID = User.Identity.GetUserId();
                db.RecipePlans.Add(recipePlans);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recipePlans);
        }

        // GET: RecipePlans/Edit/5
        public ActionResult Edit(int? id)
        {
            var recipes = (from a in db.Recipes orderby a.RecipeName select a).ToList();
            ViewBag.reci = ToSelectList(recipes);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipePlans recipePlans = db.RecipePlans.Find(id);
            if (User.Identity.GetUserId() != recipePlans.UserID && !User.IsInRole("admin"))
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View("Disable");
            }
            if (recipePlans == null)
            {
                return HttpNotFound();
            }
            return View(recipePlans);
        }

        // POST: RecipePlans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlanID,ReciName,Calorie,Quantity,Date,UserID")] RecipePlans recipePlans)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipePlans).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipePlans);
        }

        // GET: RecipePlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipePlans recipePlans = db.RecipePlans.Find(id);
            if (User.Identity.GetUserId() != recipePlans.UserID && !User.IsInRole("admin"))
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View("Disable");
            }
            if (recipePlans == null)
            {
                return HttpNotFound();
            }
            return View(recipePlans);
        }

        // POST: RecipePlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecipePlans recipePlans = db.RecipePlans.Find(id);
            if (User.Identity.GetUserId() != recipePlans.UserID && !User.IsInRole("admin"))
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View("Disable");
            }
            db.RecipePlans.Remove(recipePlans);
            db.SaveChanges();
            return RedirectToAction("Index");
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
