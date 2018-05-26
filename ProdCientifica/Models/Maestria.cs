using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProdCientifica.Models
{
    public class Maestria
    {
        [Key]
        public int MaestriaId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; }

        public virtual List<MaestriaUsuario> MaestriaUsuarios { get; set; }

    }
}