using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProdCientifica.Models
{
    public class MaestriaUsuario
    {
        [Key]
        public int MaestriaUsuarioId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha Adquirida la Maestría")]
        public DateTime FechaAdquiriolaMaestria { get; set; }

        [StringLength(255)]
        [Display(Name = "Lugar Adquirida la Maestría")]
        public string LugarAdquiriolaMaestria { get; set; }

        [Required]
        public int MaestriaId { get; set; }
        public virtual Maestria Maestria { get; set; }

        public string UsuarioId { get; set; }
        public virtual ApplicationUser Usuario { get; set; }
    }
}