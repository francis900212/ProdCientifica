using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProdCientifica.Models
{
    public class Resultado
    {
        [Key]
        public int ResultadoId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Participacomo { get; set; }

        [Required]
        [StringLength(255)]
        public string Detalles { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required]
        public int ProyectoId { get; set; }
        public virtual Proyecto Proyecto { get; set; }

        public string UsuarioId { get; set; }
        public virtual ApplicationUser Usuario { get; set; }
    }
}