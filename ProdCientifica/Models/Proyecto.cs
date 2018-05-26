using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProdCientifica.Models
{
    public class Proyecto
    {
        public int ProyectoId { get; set; }

        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(50)]
        public string Nivel { get; set; }

        public virtual List<ProyectoUsuario> Proyectousuarios { get; set; }
        public virtual List<ParticipacionEvento> Participacioneventos { get; set; }
        public virtual List<Premio> Premios { get; set; }
        public virtual List<Publicacion> Publicaciones { get; set; }
        public virtual List<RegistroPropiedad> Registropropiedades { get; set; }
        public virtual List<Resultado> Resultados { get; set; }



    }
}
