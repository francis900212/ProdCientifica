using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProdCientifica.Models
{
    public class RegistroPropiedad
    {
        [Key]
        public int RegistropropiedadId { get; set; }

        [Required]
        [StringLength(255)]
        public string RegistroNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Tipo { get; set; }

        [Required]
        [StringLength(50)]
        public string Modalidad { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }


        public int ProyectoId { get; set; }
        public virtual Proyecto proyecto { get; set; }

        public string UsuarioId { get; set; }
        public virtual ApplicationUser Usuario { get; set; }
    }
}