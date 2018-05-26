using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProdCientifica.ModelEnums
{
    public enum GradoCientifico
    {
        [Display(Name ="Doctor en Ciencias de la Salud")]
        DoctorCienciasSalud = 1,

        [Display(Name = "Doctor en Ciencias Quirúrgicas")]
        DoctorCienciasQuirurgicas = 2,

        [Display(Name = "Doctor en Ciencias Biomédicas")]
        DoctorCienciasBiomedicas = 3,

        [Display(Name = "Doctor en Ciencias Sociales")]
        DoctorCienciasSociales = 4,

        [Display(Name = "Doctor en Ciencias Clínicas")]
        DoctorCienciasClinicas = 5,

        [Display(Name = "Doctor en Ciencias Pedagógicas")]
        DoctorCienciasPedagogicas = 6,

        [Display(Name = "Doctor en Ciencias")]
        DoctorCiencia = 7,

    }
}