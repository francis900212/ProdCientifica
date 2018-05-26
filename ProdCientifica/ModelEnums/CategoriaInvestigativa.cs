using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProdCientifica.ModelEnums
{
    public enum CategoriaInvestigativa
    {
        [Display(Name = "Aspirante a Investigador")]
        AspiranteInvestigador = 1,

        [Display(Name = "Investigador Agregado")]
        InvestigadorAgregado = 2,

        [Display(Name = "Investigador Auxiliar")]
        InvestigadorAuxiliar = 3,

        [Display(Name = "Investigador Titular")]
        InvestigadorTitular = 4,

    }
}