using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProdCientifica.Models
{
    public class Asignatura
    {
        public Asignatura()
        {
            Asignaturasimparte = new List<Asignaturasimparte>();
        }

        [Key]
        public int AsignaturaId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }


        public virtual List<Asignaturasimparte> Asignaturasimparte { get; set; }
    }
}