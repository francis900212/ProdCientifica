using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProdCientifica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProdCientifica.Controllers
{
    public class UsuariosController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Usuarios
        public ActionResult Index()
        {
            var users = db.Users.Include(x => x.Departamento).Include(x => x.Departamento.CentroTrabajo).ToList();//new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            return View(users);
        }
    }
}