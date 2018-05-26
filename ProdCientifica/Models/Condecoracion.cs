using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProdCientifica.Models
{
    public class Condecoracion
    {
        [Key]
        public int CondecoracionId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(255)]
        public string Descripcion { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string UsuarioId { get; set; }
        public virtual ApplicationUser Usuario { get; set; }
    }
}