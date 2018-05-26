using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProdCientifica.Models;

namespace ProdCientifica.Controllers
{
    public class CentroTrabajoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CentroTrabajo
        public ActionResult Index()
        {
            return View(db.CentroTrabajos.ToList());
        }

        // GET: CentroTrabajo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentroTrabajo centroTrabajo = db.CentroTrabajos.Find(id);
            if (centroTrabajo == null)
            {
                return HttpNotFound();
            }
            return View(centroTrabajo);
        }

        // GET: CentroTrabajo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CentroTrabajo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CentroTrabajoId,Nombre,Direccion")] CentroTrabajo centroTrabajo)
        {
            if (ModelState.IsValid)
            {
                db.CentroTrabajos.Add(centroTrabajo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(centroTrabajo);
        }

        // GET: CentroTrabajo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentroTrabajo centroTrabajo = db.CentroTrabajos.Find(id);
            if (centroTrabajo == null)
            {
                return HttpNotFound();
            }
            return View(centroTrabajo);
        }

        // POST: CentroTrabajo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CentroTrabajoId,Nombre,Direccion")] CentroTrabajo centroTrabajo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(centroTrabajo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(centroTrabajo);
        }

        // GET: CentroTrabajo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentroTrabajo centroTrabajo = db.CentroTrabajos.Find(id);
            if (centroTrabajo == null)
            {
                return HttpNotFound();
            }
            return View(centroTrabajo);
        }

        // POST: CentroTrabajo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CentroTrabajo centroTrabajo = db.CentroTrabajos.Find(id);
            db.CentroTrabajos.Remove(centroTrabajo);
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
