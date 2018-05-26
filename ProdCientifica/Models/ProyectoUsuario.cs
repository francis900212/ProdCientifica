using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProdCientifica.Models
{
    public class ProyectoUsuario
    {
        [Key]
        public int ProyectoUsuarioId { get; set; }

        [Required]
        [StringLength(50)]
        public string Participacomo { get; set; }


        [Required]
        public int ProyectoId { get; set; }
        public virtual Proyecto Proyecto { get; set; }

        public string UsuarioId { get; set; }
        public virtual ApplicationUser Usuario { get; set; }
    }
}