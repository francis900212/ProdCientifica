using ProdCientifica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace ProdCientifica.ModelView
{
    public class MaestriaUsuarioView
    {
        public Maestria Maestria { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha Adquirida la Maestría")]
        public DateTime FechaAdquiriolaMaestria { get; set; }

        [StringLength(255)]
        [Display(Name = "Lugar Adquirida la Maestría")]
        public string LugarAdquiriolaMaestria { get; set; }
    }
}