using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_AssignmentX.Models;
using PagedList;

namespace FIT5032_AssignmentX.Controllers
{
    [Authorize (Roles ="admin")]
    public class MovementsController : Controller
    {
        private MovesContainer db = new MovesContainer();

        // GET: Movements
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var movements = from s in db.Movements select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                movements = movements.Where(s => s.MovementName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name":
                    movements = movements.OrderBy(s => s.MovementName);
                    break;
                default:
                    movements = movements.OrderByDescending(s => s.MovementName);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(movements.ToPagedList(pageNumber, pageSize));
        }

        // GET: Movements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movements movements = db.Movements.Find(id);
            if (movements == null)
            {
                return HttpNotFound();
            }
            return View(movements);
        }

        // GET: Movements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovementId,MovementName")] Movements movements)
        {
            if (ModelState.IsValid)
            {
                db.Movements.Add(movements);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movements);
        }


        // GET: Movements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movements movements = db.Movements.Find(id);
            if (movements == null)
            {
                return HttpNotFound();
            }
            return View(movements);
        }

        // POST: Movements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovementId,MovementName")] Movements movements)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movements).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movements);
        }

        // GET: Movements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movements movements = db.Movements.Find(id);
            if (movements == null)
            {
                return HttpNotFound();
            }
            return View(movements);
        }

        // POST: Movements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movements movements = db.Movements.Find(id);
            db.Movements.Remove(movements);
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
