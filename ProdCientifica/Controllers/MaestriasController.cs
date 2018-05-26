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
using ProdCientifica.ModelView;

namespace ProdCientifica.Controllers
{
    public class MaestriasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Maestrias
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var maestrias = db.MaestriaUsuarios.Include(x => x.Maestria).Include(x => x.Usuario).Where(x => x.UsuarioId == userId).ToList();
            return View(maestrias);
        }

        // GET: Maestrias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Maestria maestria = db.Maestrias.Find(id);
            var maestriaUsuario = db.MaestriaUsuarios.Include(x => x.Maestria).Include(x => x.Usuario).Where(x => x.MaestriaId == id).SingleOrDefault();
            if (maestriaUsuario == null)
            {
                return HttpNotFound();
            }
            
            return View(maestriaUsuario);
        }

        // GET: Maestrias/Create
        public ActionResult Create()
        {
            var maestriaUsuarioView = new MaestriaUsuarioView();
            return View(maestriaUsuarioView);
        }

        // POST: Maestrias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MaestriaUsuarioView maestriaUsuarioView)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var maestria = new Maestria()
                        {
                            Nombre = maestriaUsuarioView.Maestria.Nombre,
                            Descripcion = maestriaUsuarioView.Maestria.Descripcion
                        };

                        db.Maestrias.Add(maestria);
                        db.SaveChanges();
                        var maestriaId = db.Maestrias.ToList().Select(x => x.MaestriaId).Max();
                        var userId = User.Identity.GetUserId();
                        var MaestriaUsuario = new MaestriaUsuario()
                        {
                            FechaAdquiriolaMaestria = maestriaUsuarioView.FechaAdquiriolaMaestria,
                            LugarAdquiriolaMaestria = maestriaUsuarioView.LugarAdquiriolaMaestria,
                            MaestriaId = maestriaId,
                            UsuarioId = userId
                        };
                        db.MaestriaUsuarios.Add(MaestriaUsuario);
                        db.SaveChanges();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();
                        var message = "ERROR: " + ex.Message;
                        ModelState.AddModelError(string.Empty, message);
                        return View(maestriaUsuarioView);
                    }                
                }
                 
                return RedirectToAction("Index");
            }

            return View(maestriaUsuarioView);
        }

        // GET: Maestrias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Maestria maestria = db.Maestrias.Find(id);
            var maestriaUsuario = db.MaestriaUsuarios.Include(x => x.Maestria).Include(x => x.Usuario).Where(x => x.MaestriaId == id).SingleOrDefault();
            if (maestriaUsuario == null)
            {
                return HttpNotFound();
            }
            return View(maestriaUsuario);
        }

        // POST: Maestrias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MaestriaUsuario maestriaUsuario)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var maestria = db.Maestrias.Find(maestriaUsuario.MaestriaId);
                        maestria.Nombre = maestriaUsuario.Maestria.Nombre;
                        maestria.Descripcion = maestriaUsuario.Maestria.Descripcion;

                        db.Entry(maestria).State = EntityState.Modified;
                        db.SaveChanges();
                        db.Entry(maestria).State = EntityState.Detached;

                        maestriaUsuario.Maestria = maestria;
                        maestriaUsuario.Usuario = db.Users.Find(maestriaUsuario.UsuarioId);
                        db.Entry(maestriaUsuario).State = EntityState.Modified;
                        db.SaveChanges();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();
                        var message = "ERROR: " + ex.Message;
                        ModelState.AddModelError(string.Empty, message);
                        return View(maestriaUsuario);
                    }
                    return RedirectToAction("Index");
                }
                    
            }
            return View(maestriaUsuario);
        }

        // GET: Maestrias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Maestria maestria = db.Maestrias.Find(id);
            var maestriaUsuario = db.MaestriaUsuarios.Include(x => x.Maestria).Include(x => x.Usuario).Where(x => x.MaestriaId == id).SingleOrDefault();
            if (maestriaUsuario == null)
            {
                return HttpNotFound();
            }
            
            return View(maestriaUsuario);
        }

        // POST: Maestrias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    MaestriaUsuario maestriaUsuario = db.MaestriaUsuarios.Where(x => x.MaestriaId == id).SingleOrDefault();
                    db.MaestriaUsuarios.Remove(maestriaUsuario);
                    db.SaveChanges();

                    Maestria maestria = db.Maestrias.Find(id);
                    db.Maestrias.Remove(maestria);
                    db.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {

                    transaction.Rollback();
                    var message = "ERROR: " + ex.Message;
                    ModelState.AddModelError(string.Empty, message);
                    return View(id);
                }

            }

            
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
