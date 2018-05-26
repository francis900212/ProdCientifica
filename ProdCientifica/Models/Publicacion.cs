using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProdCientifica.Models
{
    public class Publicacion
    {
        [Key]
        public int PublicacionId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Nivel { get; set; }

        [Required]
        [StringLength(50)]
        public string Registro { get; set; }

        [StringLength(50)]
        public string Espesificaciones { get; set; }

        [Required]
        [StringLength(100)]
        public string PublicadoEnSitio { get; set; }

        [Required]
        [StringLength(255)]
        public string UrlSitio { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }


        [Required]
        [StringLength(50)]
        public string PublicaComo { get; set; }

        [StringLength(50)]
        public string Categoria { get; set; }


        public int? ProyectoId { get; set; }
        public virtual Proyecto Proyecto { get; set; }

        public string UsuarioId { get; set; }
        public virtual ApplicationUser Usuario { get; set; }
    }
}