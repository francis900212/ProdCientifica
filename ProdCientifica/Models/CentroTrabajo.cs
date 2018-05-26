using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProdCientifica.Models
{
    public class CentroTrabajo
    {
        [Key]
        public int CentroTrabajoId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(255)]
        public string Direccion { get; set; }

        public virtual List<Departamento> Departamentos { get; set; }
    }
}