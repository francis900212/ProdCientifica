using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProdCientifica.Models;
using Microsoft.AspNet.Identity;

namespace ProdCientifica.Controllers
{
    public class CursoImpartidosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CursoImpartidos
        public ActionResult Index()
        {
            var usuarioId = User.Identity.GetUserId();
            ViewBag.usuario = User.Identity.GetUserName();
            var cursoImpartidos = db.CursosImpartidos.Where(c => c.UsuarioId == usuarioId).ToList();
            return View(cursoImpartidos);
        }

        // GET: CursoImpartidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoImpartido cursoImpartido = db.CursosImpartidos.Include(c => c.Usuario).Where(c => c.CursoimpartidoId == id).SingleOrDefault();
            if (cursoImpartido == null)
            {
                return HttpNotFound();
            }
            return View(cursoImpartido);
        }

        // GET: CursoImpartidos/Create
        public ActionResult Create()
        {
            ViewBag.UsuariO = User.Identity.GetUserName();
            return View();
        }

        // POST: CursoImpartidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CursoImpartido cursoImpartido)
        {
            if (ModelState.IsValid)
            {
                var usuarioId = User.Identity.GetUserId();
                cursoImpartido.Usuario = db.Users.Find(usuarioId);
                cursoImpartido.UsuarioId = usuarioId;
                db.CursosImpartidos.Add(cursoImpartido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.UsuarioId = new SelectList(db.ApplicationUsers, "Id", "Nombre", cursoImpartido.UsuarioId);
            return View(cursoImpartido);
        }

        // GET: CursoImpartidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoImpartido cursoImpartido = db.CursosImpartidos.Find(id);
            if (cursoImpartido == null)
            {
                return HttpNotFound();
            }
            //ViewBag.UsuarioId = new SelectList(db.ApplicationUsers, "Id", "Nombre", cursoImpartido.UsuarioId);
            return View(cursoImpartido);
        }

        // POST: CursoImpartidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CursoimpartidoId,Nombre,ProfesorPrincipal,Tipo,nivel,Descripcion,Fecha,UsuarioId")] CursoImpartido cursoImpartido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cursoImpartido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.UsuarioId = new SelectList(db.ApplicationUsers, "Id", "Nombre", cursoImpartido.UsuarioId);
            return View(cursoImpartido);
        }

        // GET: CursoImpartidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoImpartido cursoImpartido = db.CursosImpartidos.Find(id);
            if (cursoImpartido == null)
            {
                return HttpNotFound();
            }
            return View(cursoImpartido);
        }

        // POST: CursoImpartidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CursoImpartido cursoImpartido = db.CursosImpartidos.Find(id);
            db.CursosImpartidos.Remove(cursoImpartido);
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
