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
    public class ProviderServiceController : Controller
    {
        private BusinessProjectEntities db = new BusinessProjectEntities();

        // GET: ProviderService
        public ActionResult Index()
        {
            var providerServices = db.ProviderServices.Include(p => p.provider).Include(p => p.Service);
            return View(providerServices.ToList());
        }

        // GET: ProviderService/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviderService providerService = db.ProviderServices.Find(id);
            if (providerService == null)
            {
                return HttpNotFound();
            }
            return View(providerService);
        }

        // GET: ProviderService/Create
        public ActionResult Create()
        {
            ViewBag.fkIdProvider = new SelectList(db.providers, "idProvider", "nameProvider");
            ViewBag.fkIdService = new SelectList(db.Services, "idService", "nameService");
            return View();
        }

        // POST: ProviderService/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProviderService,fkIdProvider,fkIdService")] ProviderService providerService)
        {
            if (ModelState.IsValid)
            {
                db.ProviderServices.Add(providerService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fkIdProvider = new SelectList(db.providers, "idProvider", "nameProvider", providerService.fkIdProvider);
            ViewBag.fkIdService = new SelectList(db.Services, "idService", "nameService", providerService.fkIdService);
            return View(providerService);
        }

        // GET: ProviderService/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviderService providerService = db.ProviderServices.Find(id);
            if (providerService == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkIdProvider = new SelectList(db.providers, "idProvider", "nameProvider", providerService.fkIdProvider);
            ViewBag.fkIdService = new SelectList(db.Services, "idService", "nameService", providerService.fkIdService);
            return View(providerService);
        }

        // POST: ProviderService/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProviderService,fkIdProvider,fkIdService")] ProviderService providerService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(providerService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fkIdProvider = new SelectList(db.providers, "idProvider", "nameProvider", providerService.fkIdProvider);
            ViewBag.fkIdService = new SelectList(db.Services, "idService", "nameService", providerService.fkIdService);
            return View(providerService);
        }

        // GET: ProviderService/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviderService providerService = db.ProviderServices.Find(id);
            if (providerService == null)
            {
                return HttpNotFound();
            }
            return View(providerService);
        }

        // POST: ProviderService/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProviderService providerService = db.ProviderServices.Find(id);
            db.ProviderServices.Remove(providerService);
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
