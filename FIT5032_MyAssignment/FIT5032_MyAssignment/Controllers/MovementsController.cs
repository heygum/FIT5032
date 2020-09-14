using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_MyAssignment.Models;

namespace FIT5032_MyAssignment.Controllers
{
    [Authorize(Users ="manager1@boxer.com")]
    public class MovementsController : Controller
    {
        private ManageMovesContainer db = new ManageMovesContainer();

        // GET: Movements
        public ActionResult Index()
        {
            return View(db.Movements.ToList());
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
        //[Authorize(Users ="manager1@boxer.com")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovementID,MovementName")] Movements movements)
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
        public ActionResult Edit([Bind(Include = "MovementID,MovementName")] Movements movements)
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
