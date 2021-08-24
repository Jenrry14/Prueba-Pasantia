using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PruebaPasantia;

namespace PruebaPasantia.Controllers
{
    public class DireccionesController : Controller
    {
        private PruebaTrabajoEntities1 db = new PruebaTrabajoEntities1();

        // GET: Direcciones
        public ActionResult Index()
        {
            return View(db.Direcciones.ToList());
        }

        // GET: Direcciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccione direccione = db.Direcciones.Find(id);
            if (direccione == null)
            {
                return HttpNotFound();
            }
            return View(direccione);
        }

        // GET: Direcciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Direcciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDireccion,Direccion")] Direccione direccione)
        {
            if (ModelState.IsValid)
            {
                db.Direcciones.Add(direccione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(direccione);
        }

        // GET: Direcciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccione direccione = db.Direcciones.Find(id);
            if (direccione == null)
            {
                return HttpNotFound();
            }
            return View(direccione);
        }

        // POST: Direcciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDireccion,Direccion")] Direccione direccione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(direccione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(direccione);
        }

        // GET: Direcciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccione direccione = db.Direcciones.Find(id);
            if (direccione == null)
            {
                return HttpNotFound();
            }
            return View(direccione);
        }

        // POST: Direcciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Direccione direccione = db.Direcciones.Find(id);
            db.Direcciones.Remove(direccione);
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
