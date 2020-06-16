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
    public class ServiceSalesmanController : Controller
    {
        private BusinessProjectEntities db = new BusinessProjectEntities();

        // GET: ServiceSalesman
        public ActionResult Index()
        {
            var serviceSalesmen = db.ServiceSalesmen.Include(s => s.SalesMan).Include(s => s.Service);
            return View(serviceSalesmen.ToList());
        }

        // GET: ServiceSalesman/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceSalesman serviceSalesman = db.ServiceSalesmen.Find(id);
            if (serviceSalesman == null)
            {
                return HttpNotFound();
            }
            return View(serviceSalesman);
        }

        // GET: ServiceSalesman/Create
        public ActionResult Create()
        {
            ViewBag.fkIdSalesman = new SelectList(db.SalesMen, "idSalesMan", "nameSalesman");
            ViewBag.fkidService = new SelectList(db.Services, "idService", "nameService");
            return View();
        }

        // POST: ServiceSalesman/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idServiceSalesman,fkidService,fkIdSalesman,totalCommissionServiceSalesman")] ServiceSalesman serviceSalesman)
        {
            if (ModelState.IsValid)
            {
                db.ServiceSalesmen.Add(serviceSalesman);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fkIdSalesman = new SelectList(db.SalesMen, "idSalesMan", "nameSalesman", serviceSalesman.fkIdSalesman);
            ViewBag.fkidService = new SelectList(db.Services, "idService", "nameService", serviceSalesman.fkidService);
            return View(serviceSalesman);
        }

        // GET: ServiceSalesman/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceSalesman serviceSalesman = db.ServiceSalesmen.Find(id);
            if (serviceSalesman == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkIdSalesman = new SelectList(db.SalesMen, "idSalesMan", "nameSalesman", serviceSalesman.fkIdSalesman);
            ViewBag.fkidService = new SelectList(db.Services, "idService", "nameService", serviceSalesman.fkidService);
            return View(serviceSalesman);
        }

        // POST: ServiceSalesman/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idServiceSalesman,fkidService,fkIdSalesman,totalCommissionServiceSalesman")] ServiceSalesman serviceSalesman)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceSalesman).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fkIdSalesman = new SelectList(db.SalesMen, "idSalesMan", "nameSalesman", serviceSalesman.fkIdSalesman);
            ViewBag.fkidService = new SelectList(db.Services, "idService", "nameService", serviceSalesman.fkidService);
            return View(serviceSalesman);
        }

        // GET: ServiceSalesman/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceSalesman serviceSalesman = db.ServiceSalesmen.Find(id);
            if (serviceSalesman == null)
            {
                return HttpNotFound();
            }
            return View(serviceSalesman);
        }

        // POST: ServiceSalesman/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceSalesman serviceSalesman = db.ServiceSalesmen.Find(id);
            db.ServiceSalesmen.Remove(serviceSalesman);
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
