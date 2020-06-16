using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessProject.Models;

namespace BusinessProject.Controllers
{
    public class typeProviderController : Controller
    {
        private BusinessProjectEntities db = new BusinessProjectEntities();

        // GET: typeProvider
        public ActionResult Index()
        {
            return View(db.typeProviders.ToList());
        }

        // GET: typeProvider/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            typeProvider typeProvider = db.typeProviders.Find(id);
            if (typeProvider == null)
            {
                return HttpNotFound();
            }
            return View(typeProvider);
        }

        // GET: typeProvider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: typeProvider/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProvider,nameTypeProvider,descriptionProvider")] typeProvider typeProvider)
        {
            if (ModelState.IsValid)
            {
                db.typeProviders.Add(typeProvider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeProvider);
        }

        // GET: typeProvider/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            typeProvider typeProvider = db.typeProviders.Find(id);
            if (typeProvider == null)
            {
                return HttpNotFound();
            }
            return View(typeProvider);
        }

        // POST: typeProvider/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProvider,nameTypeProvider,descriptionProvider")] typeProvider typeProvider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeProvider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeProvider);
        }

        // GET: typeProvider/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            typeProvider typeProvider = db.typeProviders.Find(id);
            if (typeProvider == null)
            {
                return HttpNotFound();
            }
            return View(typeProvider);
        }

        // POST: typeProvider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            typeProvider typeProvider = db.typeProviders.Find(id);
            db.typeProviders.Remove(typeProvider);
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
