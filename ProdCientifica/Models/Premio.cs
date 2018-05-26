using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProdCientifica.Models
{
    public class Premio
    {
        [Key]
        public int PremioId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string ConvocadoPor { get; set; }

        [Required]
        [StringLength(50)]
        public string Nivel { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required]
        public int ProyectoId { get; set; }
        public virtual Proyecto Proyecto { get; set; }

        public string UsuarioId { get; set; }
        public virtual ApplicationUser Usuario { get; set; }
    }
}