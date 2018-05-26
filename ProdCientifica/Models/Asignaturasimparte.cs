using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProdCientifica.Models
{
    public class Asignaturasimparte
    {
        [Key]
        public int AsignaturasimparteId { get; set; }

        [Required]
        public int AsignaturaId { get; set; }
        public virtual Asignatura Asignatura { get; set; }

        public string UsuarioId { get; set; }
        public virtual ApplicationUser Usuario { get; set; }
    }
}