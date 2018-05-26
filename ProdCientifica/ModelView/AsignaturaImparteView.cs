using ProdCientifica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProdCientifica.ModelView
{
    public class AsignaturaImparteView
    {

        public List<Asignatura> Asignaturas { get; set; }
        public ApplicationUser User { get; set; }
    }
}