using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ProdCientifica.Models;
using ProdCientifica.ModelView;

namespace ProdCientifica.Controllers
{
    public class AsignaturaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Asignatura
        public ActionResult Index()
        {
            return View(db.Asignaturas.ToList());
        }

        // GET: Asignatura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignatura asignatura = db.Asignaturas.Find(id);
            if (asignatura == null)
            {
                return HttpNotFound();
            }
            return View(asignatura);
        }

        // GET: Asignatura/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Asignatura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AsignaturaId,Nombre,Descripcion")] Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                db.Asignaturas.Add(asignatura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asignatura);
        }

        // GET: Asignatura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignatura asignatura = db.Asignaturas.Find(id);
            if (asignatura == null)
            {
                return HttpNotFound();
            }
            return View(asignatura);
        }

        // POST: Asignatura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AsignaturaId,Nombre,Descripcion")] Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asignatura);
        }

        // GET: Asignatura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignatura asignatura = db.Asignaturas.Find(id);
            if (asignatura == null)
            {
                return HttpNotFound();
            }
            return View(asignatura);
        }

        // POST: Asignatura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asignatura asignatura = db.Asignaturas.Find(id);
            try
            {    
                db.Asignaturas.Remove(asignatura);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                return View(asignatura);
                ViewBag.Error = "Error: " + ex.Message;
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult AsignaturasImparte()
        {
            var userId = User.Identity.GetUserId();
            var asignaturasImparte = db.Asignaturasimparte.Include(x => x.Asignatura).Where(x => x.UsuarioId == userId);
            ViewBag.Usuario = User.Identity.GetUserName();
            return View(asignaturasImparte);
        }

        public ActionResult CreateAsignaturaImparte()
        {
            var usuarioId = User.Identity.GetUserId();
            AsignaturaImparteView asignaturaImparteView = new AsignaturaImparteView();
            asignaturaImparteView.Asignaturas = db.Asignaturas.ToList();

            asignaturaImparteView.User = db.Users.Find(usuarioId);
            List<Asignaturasimparte> asignaturasImparte = db.Asignaturasimparte.Where(x => x.UsuarioId == usuarioId).ToList();
            ViewBag.asignaturasImparte = asignaturasImparte;
            return View(asignaturaImparteView);
        }

        [HttpPost]
        public ActionResult CreateAsignaturaImparte(int []asignaturas)
        {
            var userId = User.Identity.GetUserId();
            if (asignaturas != null)
            {
                for (int i = 0; i < asignaturas.Length; i++)
                {
                    Asignaturasimparte asignaturaImparte = new Asignaturasimparte()
                    {
                        AsignaturaId = asignaturas[i],
                        UsuarioId = userId
                    };
                    db.Asignaturasimparte.Add(asignaturaImparte);
                }
                db.SaveChanges();
                
            }

            return RedirectToAction("AsignaturasImparte");
        }

        public ActionResult DetailsAsignaturaImparte(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignaturasimparte asignaturasImparte = db.Asignaturasimparte.Find(id);
            if (asignaturasImparte == null)
            {
                return HttpNotFound();
            }
            ViewBag.Usuario = User.Identity.GetUserName();
            return View(asignaturasImparte);
        }


        public ActionResult DeleteAsignaturaImparte(int? id)
        {
            Asignaturasimparte asignaturaImparte = db.Asignaturasimparte.Find(id);
            try
            {
                db.Asignaturasimparte.Remove(asignaturaImparte);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                return RedirectToAction("AsignaturasImparte");
                //ViewBag.Error = "Error: " + ex.Message;
            }

            return RedirectToAction("AsignaturasImparte");
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
