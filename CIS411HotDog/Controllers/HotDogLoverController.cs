using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CIS411HotDog.Models;

namespace CIS411HotDog.Controllers
{
    public class HotDogLoverController : Controller
    {
        private ProfileDBContext db = new ProfileDBContext();

        // GET: /HotDogLover/
        public ActionResult Index()
        {
            return View(db.CIS411HotDogs.ToList());
        }

        // GET: /HotDogLover/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotDogLover hotdoglover = db.CIS411HotDogs.Find(id);
            if (hotdoglover == null)
            {
                return HttpNotFound();
            }
            return View(hotdoglover);
        }

        // GET: /HotDogLover/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /HotDogLover/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Name,Bio,Favorite,LastAte")] HotDogLover hotdoglover)
        {
            if (ModelState.IsValid)
            {
                db.CIS411HotDogs.Add(hotdoglover);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hotdoglover);
        }

        // GET: /HotDogLover/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotDogLover hotdoglover = db.CIS411HotDogs.Find(id);
            if (hotdoglover == null)
            {
                return HttpNotFound();
            }
            return View(hotdoglover);
        }

        // POST: /HotDogLover/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name,Bio,Favorite,LastAte")] HotDogLover hotdoglover)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotdoglover).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotdoglover);
        }

        // GET: /HotDogLover/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotDogLover hotdoglover = db.CIS411HotDogs.Find(id);
            if (hotdoglover == null)
            {
                return HttpNotFound();
            }
            return View(hotdoglover);
        }

        // POST: /HotDogLover/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HotDogLover hotdoglover = db.CIS411HotDogs.Find(id);
            db.CIS411HotDogs.Remove(hotdoglover);
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
