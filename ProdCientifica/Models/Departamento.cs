using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProdCientifica.Models
{
    public class Departamento
    {   
        [Required]
        public int DepartamentoId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(255)]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name ="Centro de Trabajo")]
        public int CentroTrabajoId { get; set; }
        public virtual CentroTrabajo CentroTrabajo { get; set; }


        public virtual List<ApplicationUser> ApplicationUsers { get; set; }
    }
}