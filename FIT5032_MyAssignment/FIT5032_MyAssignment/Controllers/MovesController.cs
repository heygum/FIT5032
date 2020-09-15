using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_MyAssignment.Models;
using Microsoft.AspNet.Identity;

namespace FIT5032_MyAssignment.Controllers
{
    public class MovesController : Controller
    {
        private MovesContainer db = new MovesContainer();

        private Boolean vali()
        {
            String id = User.Identity.GetUserId();
            if (id != null)
                return true;
            return false;
        }
        // GET: Moves
        public ActionResult Index()
        {
            if (vali())
                return View(db.Moves.ToList());
            else
                return RedirectToActionPermanent("Login","Account");
        }

        // GET: Moves/Details/5
        public ActionResult Details(int? id)
        {
            if (vali())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Moves moves = db.Moves.Find(id);
                if (moves == null)
                {
                    return HttpNotFound();
                }
                return View(moves);
            }
            return RedirectToActionPermanent("Login", "Account");
        }

        // GET: Moves/Create
        public ActionResult Create()
        {
            if (vali())
            {
              
                List<String> _list = new List<String>();

                ViewBag.data = _list.AsEnumerable();
                return View();
            }        
            return RedirectToActionPermanent("Login", "Account");
        }

        // POST: Moves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MoveID,MoveName,Times,Rounds,Date")] Moves moves)
        {
            if (vali())
            {
                if (ModelState.IsValid)
                {
                    db.Moves.Add(moves);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(moves);
            }
            return RedirectToActionPermanent("Login", "Account");
        }

        // GET: Moves/Edit/5
        public ActionResult Edit(int? id)
        {
            if (vali())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Moves moves = db.Moves.Find(id);
                if (moves == null)
                {
                    return HttpNotFound();
                }
                return View(moves);
            }
            return RedirectToActionPermanent("Login", "Account");
        }

        // POST: Moves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MoveID,MoveName,Times,Rounds,Date")] Moves moves)
        {
            if (vali())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(moves).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(moves);
            }
            return RedirectToActionPermanent("Login", "Account");
        }

        // GET: Moves/Delete/5
        public ActionResult Delete(int? id)
        {
            if (vali())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Moves moves = db.Moves.Find(id);
                if (moves == null)
                {
                    return HttpNotFound();
                }
                return View(moves);
            }
            return RedirectToActionPermanent("Login", "Account");
        }

        // POST: Moves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (vali())
            {
                Moves moves = db.Moves.Find(id);
                db.Moves.Remove(moves);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToActionPermanent("Login", "Account");
        }

        protected override void Dispose(bool disposing)
        {
            if (vali())
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }

        }
    }
}
