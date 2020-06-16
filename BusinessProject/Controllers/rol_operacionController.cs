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
    public class rol_operacionController : Controller
    {
        private BusinessProjectEntities db = new BusinessProjectEntities();

        // GET: rol_operacion
        public ActionResult Index()
        {
            var rol_operacion = db.rol_operacion.Include(r => r.operacione).Include(r => r.rol);
            return View(rol_operacion.ToList());
        }

        // GET: rol_operacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rol_operacion rol_operacion = db.rol_operacion.Find(id);
            if (rol_operacion == null)
            {
                return HttpNotFound();
            }
            return View(rol_operacion);
        }

        // GET: rol_operacion/Create
        public ActionResult Create()
        {
            ViewBag.idOperacion = new SelectList(db.operaciones, "id", "nombre");
            ViewBag.idRol = new SelectList(db.rols, "id", "nombre");
            return View();
        }

        // POST: rol_operacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idRol,idOperacion")] rol_operacion rol_operacion)
        {
            if (ModelState.IsValid)
            {
                db.rol_operacion.Add(rol_operacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idOperacion = new SelectList(db.operaciones, "id", "nombre", rol_operacion.idOperacion);
            ViewBag.idRol = new SelectList(db.rols, "id", "nombre", rol_operacion.idRol);
            return View(rol_operacion);
        }

        // GET: rol_operacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rol_operacion rol_operacion = db.rol_operacion.Find(id);
            if (rol_operacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idOperacion = new SelectList(db.operaciones, "id", "nombre", rol_operacion.idOperacion);
            ViewBag.idRol = new SelectList(db.rols, "id", "nombre", rol_operacion.idRol);
            return View(rol_operacion);
        }

        // POST: rol_operacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idRol,idOperacion")] rol_operacion rol_operacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rol_operacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idOperacion = new SelectList(db.operaciones, "id", "nombre", rol_operacion.idOperacion);
            ViewBag.idRol = new SelectList(db.rols, "id", "nombre", rol_operacion.idRol);
            return View(rol_operacion);
        }

        // GET: rol_operacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rol_operacion rol_operacion = db.rol_operacion.Find(id);
            if (rol_operacion == null)
            {
                return HttpNotFound();
            }
            return View(rol_operacion);
        }

        // POST: rol_operacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rol_operacion rol_operacion = db.rol_operacion.Find(id);
            db.rol_operacion.Remove(rol_operacion);
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
