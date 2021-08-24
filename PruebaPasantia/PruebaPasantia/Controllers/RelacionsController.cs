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
    public class RelacionsController : Controller
    {
        private PruebaTrabajoEntities1 db = new PruebaTrabajoEntities1();

        // GET: Relacions
        public ActionResult Index()
        {
            var relacions = db.Relacions.Include(r => r.Cliente).Include(r => r.Direccione);
            return View(relacions.ToList());
        }

        // GET: Relacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relacion relacion = db.Relacions.Find(id);
            if (relacion == null)
            {
                return HttpNotFound();
            }
            return View(relacion);
        }

        // GET: Relacions/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Nombre_Completo");
            ViewBag.IdDireccion = new SelectList(db.Direcciones, "IdDireccion", "Direccion");
            return View();
        }

        // POST: Relacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRelacion,IdCliente,IdDireccion")] Relacion relacion)
        {
            if (ModelState.IsValid)
            {
                db.Relacions.Add(relacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Nombre_Completo", relacion.IdCliente);
            ViewBag.IdDireccion = new SelectList(db.Direcciones, "IdDireccion", "Direccion", relacion.IdDireccion);
            return View(relacion);
        }

        // GET: Relacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relacion relacion = db.Relacions.Find(id);
            if (relacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Nombre_Completo", relacion.IdCliente);
            ViewBag.IdDireccion = new SelectList(db.Direcciones, "IdDireccion", "Direccion", relacion.IdDireccion);
            return View(relacion);
        }

        // POST: Relacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRelacion,IdCliente,IdDireccion")] Relacion relacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Nombre_Completo", relacion.IdCliente);
            ViewBag.IdDireccion = new SelectList(db.Direcciones, "IdDireccion", "Direccion", relacion.IdDireccion);
            return View(relacion);
        }

        // GET: Relacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relacion relacion = db.Relacions.Find(id);
            if (relacion == null)
            {
                return HttpNotFound();
            }
            return View(relacion);
        }

        // POST: Relacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Relacion relacion = db.Relacions.Find(id);
            db.Relacions.Remove(relacion);
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
