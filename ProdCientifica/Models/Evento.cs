using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProdCientifica.Models
{
    public class Evento
    {
        [Key]
        public int EventoId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(255)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(255)]
        public string Nivel { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }


       public virtual List<ParticipacionEvento> Participacioneventos { get; set; }
    }
}