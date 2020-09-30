using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_AssignmentX.Models;
using PagedList;

namespace FIT5032_AssignmentX.Controllers
{
    [Authorize(Roles = "admin")]
    public class RecipesController : Controller
    {
        private RecipeContainer db = new RecipeContainer();

        // GET: Recipes
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name" : "";
            ViewBag.CalorieSortParm = sortOrder == "Calorie" ? "calorie_desc" : "Calorie";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var recipes = from s in db.Recipes select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                recipes = recipes.Where(s => s.RecipeName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name":
                    recipes = recipes.OrderBy(s => s.RecipeName);
                    break;
                case "Calorie":
                    recipes = recipes.OrderBy(s => s.Calorie);
                    break;
                case "calorie_desc":
                    recipes = recipes.OrderByDescending(s => s.Calorie);
                    break;
                default:
                    recipes = recipes.OrderByDescending(s => s.RecipeName);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(recipes.ToPagedList(pageNumber, pageSize));
        }

        // GET: Recipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipes recipes = db.Recipes.Find(id);
            if (recipes == null)
            {
                return HttpNotFound();
            }
            return View(recipes);
        }

        // GET: Recipes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecipeID,RecipeName,Calorie")] Recipes recipes)
        {
            if (ModelState.IsValid)
            {
                db.Recipes.Add(recipes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recipes);
        }

        // GET: Recipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipes recipes = db.Recipes.Find(id);
            if (recipes == null)
            {
                return HttpNotFound();
            }
            return View(recipes);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecipeID,RecipeName,Calorie")] Recipes recipes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipes);
        }

        // GET: Recipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipes recipes = db.Recipes.Find(id);
            if (recipes == null)
            {
                return HttpNotFound();
            }
            return View(recipes);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipes recipes = db.Recipes.Find(id);
            db.Recipes.Remove(recipes);
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
