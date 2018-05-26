using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProdCientifica.Models
{
    public class ParticipacionEvento
    {
        [Key]
        public int ParticipacioneventoId { get; set; }

        [Required]
        [StringLength(255)]
        public string ParticipoComo { get; set; }


        [StringLength(255)]
        public string Titulo { get; set; }

        [Required]
        public int EventoId { get; set; }
        public virtual Evento Evento { get; set; }

        public int ProyectoId { get; set; }
        public virtual Proyecto Proyecto { get; set; }

        public string UsuarioId { get; set; }
        public virtual ApplicationUser Usuario { get; set; }
    }
}