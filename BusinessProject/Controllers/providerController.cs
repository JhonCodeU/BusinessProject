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
    public class providerController : Controller
    {
        private BusinessProjectEntities db = new BusinessProjectEntities();

        // GET: provider
        public ActionResult Index()
        {
            var providers = db.providers.Include(p => p.typeProvider);
            return View(providers.ToList());
        }

        // GET: provider/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            provider provider = db.providers.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }
            return View(provider);
        }

        // GET: provider/Create
        public ActionResult Create()
        {
            ViewBag.fkTypeProvider = new SelectList(db.typeProviders, "idProvider", "nameTypeProvider");
            return View();
        }

        // POST: provider/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProvider,nameProvider,addressProvider,emailAddressProvider,phoneProvider,descriptionProvider,fkTypeProvider")] provider provider)
        {
            if (ModelState.IsValid)
            {
                db.providers.Add(provider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fkTypeProvider = new SelectList(db.typeProviders, "idProvider", "nameTypeProvider", provider.fkTypeProvider);
            return View(provider);
        }

        // GET: provider/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            provider provider = db.providers.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkTypeProvider = new SelectList(db.typeProviders, "idProvider", "nameTypeProvider", provider.fkTypeProvider);
            return View(provider);
        }

        // POST: provider/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProvider,nameProvider,addressProvider,emailAddressProvider,phoneProvider,descriptionProvider,fkTypeProvider")] provider provider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fkTypeProvider = new SelectList(db.typeProviders, "idProvider", "nameTypeProvider", provider.fkTypeProvider);
            return View(provider);
        }

        // GET: provider/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            provider provider = db.providers.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }
            return View(provider);
        }

        // POST: provider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            provider provider = db.providers.Find(id);
            db.providers.Remove(provider);
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
