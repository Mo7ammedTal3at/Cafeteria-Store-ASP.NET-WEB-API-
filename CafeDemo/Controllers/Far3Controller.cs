using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CafeDemo.Models;
using CafeDemo.Models.EnumClasses;

namespace CafeDemo.Controllers
{
    public class Far3Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Far3
        public ActionResult Index()
        {
            return View(db.Far3.ToList());
        }

        // GET: Far3/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Far3 far3 = db.Far3.Find(id);
            if (far3 == null)
            {
                return HttpNotFound();
            }
            return View(far3);
        }

        // GET: Far3/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Far3/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Far3 far3)
        {
            if (ModelState.IsValid)
            {
                db.Far3.Add(far3);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(far3);
        }

        // GET: Far3/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Far3 far3 = db.Far3.Find(id);
            if (far3 == null)
            {
                return HttpNotFound();
            }
            return View(far3);
        }

        // POST: Far3/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Far3 far3)
        {
            if (ModelState.IsValid)
            {
                db.Entry(far3).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(far3);
        }

        // GET: Far3/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Far3 far3 = db.Far3.Find(id);
            if (far3 == null)
            {
                return HttpNotFound();
            }
            return View(far3);
        }

        // POST: Far3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Far3 far3 = db.Far3.Find(id);
            db.Far3.Remove(far3);
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
