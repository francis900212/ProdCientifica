using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.ModelBinding;
using ProdCientifica.ModelEnums;

namespace ProdCientifica.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre y Apellidos")]
        public string Nombre { get; set; }

        [EnumDataType(typeof(Sexo))]
        [BindRequired]
        public Sexo Sexo { get; set; }

        [BindRequired]
        public int Ci { get; set; }

        [EnumDataType(typeof(TituloGraduado))]
        [BindRequired]
        [Display(Name = "Titulo de Graduado")]
        public TituloGraduado? TituloGraduado { get; set; }

        [EnumDataType(typeof(CategoriaDocente))]
        [BindRequired]
        [Display(Name = "Categoria Docente")]
        public CategoriaDocente? CategoriaDocente { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Año Inicio como Docente")]
        public DateTime? AnnoInicioDocente { get; set; }


        [EnumDataType(typeof(EvaluacionDocente))]
        [BindRequired]
        [Display(Name = "Ultima Evaluacion como Docente")]
        public EvaluacionDocente? UltimaEvaluacionDocente { get; set; }

        [Display(Name = "Profesor Consultante")]
        [BindRequired]
        public Boolean ProfesorConsultante { get; set; }

        [EnumDataType(typeof(CategoriaInvestigativa))]
        [BindRequired]
        [Display(Name = "Categoria Investigativa")]
        public CategoriaInvestigativa? CategoriaInvestigativa { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Año de adquirida la Categoría Investigativa")]
        public DateTime? AnnoCategoriaInvestigativa { get; set; }

        [EnumDataType(typeof(GradoCientifico))]
        [BindRequired]
        [Display(Name = "Grado Científico")]
        public GradoCientifico? GradoCientifico { get; set; }

        [Display(Name = "Dr. Honoris Causa")]
        [BindRequired]
        public Boolean HonorisCausa { get; set; }

        [Display(Name = "Profesor de Mérito")]
        [BindRequired]
        public Boolean ProfesorMerito { get; set; }

        [Display(Name = "Pertenece al Claustro")]
        [BindRequired]
        public Boolean PerteneceAlClaustro { get; set; }

        [StringLength(100)]
        [Display(Name = "Especialista de 1er Grado en")]
        public string Especialista1erGrado { get; set; }

        [StringLength(100)]
        [Display(Name = "Especialista de 2do Grado en")]
        public string Especialista2doGrado { get; set; }

        public string Path { get; set; }

        [BindRequired]
        [Display(Name = "Departamento")]
        public int DepartamentoId { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
