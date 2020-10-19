using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_AssignmentX.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FIT5032_AssignmentX.Controllers
{
    [ValidateInput(false)]
    public class MapLocationsController : Controller
    {
        private MapContainer db = new MapContainer();

        // GET: MapLocations
        public ActionResult Index()
        {
            //list<maplocation> des = (from a in db.maplocations orderby a.description select a).tolist();
            //list<string> name = new list<string>();
            //var i = 0;
            //foreach (var m in des)
            //{
            //    list<string> co = new list<string>();
            //    co.add(m.latitude);
            //    co.add(m.longitude);
            //    i++;
            //    var result = new
            //    {
            //        type = "feature",
            //        properties = new { description = "<strong>" + m.locationname.tostring() + "</strong>" + m.description.tostring() },
            //        geometry = new
            //        {
            //            type = "point",
            //            coordinates = co.tostring()
            //        }
            //    };
            //    name.add(result.tostring());
            //}
            //viewbag.str = name;
            return View(db.MapLocations.ToList());
        }

        // GET: MapLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapLocation mapLocation = db.MapLocations.Find(id);
            if (mapLocation == null)
            {
                return HttpNotFound();
            }
            return View(mapLocation);
        }

        // GET: MapLocations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MapLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocationId,LocationName,longitude,Latitude,Description")] MapLocation mapLocation)
        {
            if (ModelState.IsValid)
            {
                db.MapLocations.Add(mapLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mapLocation);
        }

        // GET: MapLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapLocation mapLocation = db.MapLocations.Find(id);
            if (mapLocation == null)
            {
                return HttpNotFound();
            }
            return View(mapLocation);
        }

        // POST: MapLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocationId,LocationName,longitude,Latitude,Description")] MapLocation mapLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mapLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mapLocation);
        }

        // GET: MapLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MapLocation mapLocation = db.MapLocations.Find(id);
            if (mapLocation == null)
            {
                return HttpNotFound();
            }
            return View(mapLocation);
        }

        // POST: MapLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MapLocation mapLocation = db.MapLocations.Find(id);
            db.MapLocations.Remove(mapLocation);
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
