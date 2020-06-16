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
    public class customerServiceController : Controller
    {
        private BusinessProjectEntities db = new BusinessProjectEntities();

        // GET: customerService
        public ActionResult Index()
        {
            var customerServices = db.customerServices.Include(c => c.customer).Include(c => c.Service);
            return View(customerServices.ToList());
        }

        // GET: customerService/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customerService customerService = db.customerServices.Find(id);
            if (customerService == null)
            {
                return HttpNotFound();
            }
            return View(customerService);
        }

        // GET: customerService/Create
        public ActionResult Create()
        {
            ViewBag.fkidCustomer = new SelectList(db.customers, "idCustomer", "nameCustomer");
            ViewBag.fkidService = new SelectList(db.Services, "idService", "nameService");
            return View();
        }

        // POST: customerService/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCustomerService,fkidCustomer,fkidService,sessionsNumber")] customerService customerService)
        {
            if (ModelState.IsValid)
            {
                db.customerServices.Add(customerService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fkidCustomer = new SelectList(db.customers, "idCustomer", "nameCustomer", customerService.fkidCustomer);
            ViewBag.fkidService = new SelectList(db.Services, "idService", "nameService", customerService.fkidService);
            return View(customerService);
        }

        // GET: customerService/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customerService customerService = db.customerServices.Find(id);
            if (customerService == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkidCustomer = new SelectList(db.customers, "idCustomer", "nameCustomer", customerService.fkidCustomer);
            ViewBag.fkidService = new SelectList(db.Services, "idService", "nameService", customerService.fkidService);
            return View(customerService);
        }

        // POST: customerService/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCustomerService,fkidCustomer,fkidService,sessionsNumber")] customerService customerService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fkidCustomer = new SelectList(db.customers, "idCustomer", "nameCustomer", customerService.fkidCustomer);
            ViewBag.fkidService = new SelectList(db.Services, "idService", "nameService", customerService.fkidService);
            return View(customerService);
        }

        // GET: customerService/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customerService customerService = db.customerServices.Find(id);
            if (customerService == null)
            {
                return HttpNotFound();
            }
            return View(customerService);
        }

        // POST: customerService/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            customerService customerService = db.customerServices.Find(id);
            db.customerServices.Remove(customerService);
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
