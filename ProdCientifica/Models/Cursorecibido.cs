using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using ProdCientifica.ModelEnums;

namespace ProdCientifica.Models
{
    public class Cursorecibido
    {
        [Key]
        public int CursorecibidoId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [BindRequired]
        [EnumDataType(typeof(SuperacionTipo))]
        public SuperacionTipo Tipo { get; set; }

        [BindRequired]
        [EnumDataType(typeof(SuperacionNivel))]
        public SuperacionNivel nivel { get; set; }

        [StringLength(255)]
        public String Descripcion { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public string UsuarioId { get; set; }
        public virtual ApplicationUser Usuario { get; set; }
    }
}