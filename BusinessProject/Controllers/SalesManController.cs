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
    public class SalesManController : Controller
    {
        private BusinessProjectEntities db = new BusinessProjectEntities();

        // GET: SalesMan
        public ActionResult Index()
        {
            return View(db.SalesMen.ToList());
        }

        // GET: SalesMan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesMan salesMan = db.SalesMen.Find(id);
            if (salesMan == null)
            {
                return HttpNotFound();
            }
            return View(salesMan);
        }

        // GET: SalesMan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalesMan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSalesMan,nameSalesman,addressSalesMan,emailAddressSalesMan,phoneProvider,salarySalesMan")] SalesMan salesMan)
        {
            if (ModelState.IsValid)
            {
                db.SalesMen.Add(salesMan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salesMan);
        }

        // GET: SalesMan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesMan salesMan = db.SalesMen.Find(id);
            if (salesMan == null)
            {
                return HttpNotFound();
            }
            return View(salesMan);
        }

        // POST: SalesMan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSalesMan,nameSalesman,addressSalesMan,emailAddressSalesMan,phoneProvider,salarySalesMan")] SalesMan salesMan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesMan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salesMan);
        }

        // GET: SalesMan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesMan salesMan = db.SalesMen.Find(id);
            if (salesMan == null)
            {
                return HttpNotFound();
            }
            return View(salesMan);
        }

        // POST: SalesMan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesMan salesMan = db.SalesMen.Find(id);
            db.SalesMen.Remove(salesMan);
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
