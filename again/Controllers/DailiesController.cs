using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using again.Models;

namespace again.Controllers
{
    public class DailiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Dailies
        public ActionResult Index()
        {
            return View(db.Dailies.ToList());
        }

        // GET: Dailies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Daily daily = db.Dailies.Find(id);
            if (daily == null)
            {
                return HttpNotFound();
            }
            return View(daily);
        }

        // GET: Dailies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dailies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HourlyRate,Bonus")] Daily daily)
        {
            if (ModelState.IsValid)
            {
                db.Dailies.Add(daily);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(daily);
        }

        // GET: Dailies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Daily daily = db.Dailies.Find(id);
            if (daily == null)
            {
                return HttpNotFound();
            }
            return View(daily);
        }

        // POST: Dailies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HourlyRate,Bonus")] Daily daily)
        {
            if (ModelState.IsValid)
            {
                db.Entry(daily).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(daily);
        }

        // GET: Dailies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Daily daily = db.Dailies.Find(id);
            if (daily == null)
            {
                return HttpNotFound();
            }
            return View(daily);
        }

        // POST: Dailies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Daily daily = db.Dailies.Find(id);
            db.Dailies.Remove(daily);
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
