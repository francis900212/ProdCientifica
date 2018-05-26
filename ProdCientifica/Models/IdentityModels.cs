using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProdCientifica.ModelEnums;

namespace ProdCientifica.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

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
        public int DepartamentoId { get; set; }
        public virtual Departamento Departamento { get; set; }

        public virtual List<Asignaturasimparte> Asignaturasimparte { get; set; }
        public virtual List<MaestriaUsuario> MaestriaUsuarios { get; set; }
        public virtual List<Cursorecibido> Cursorecibidos { get; set; }
        public virtual List<CursoImpartido> CursosImpartidos { get; set; }
        public virtual List<Condecoracion> Condecoracion { get; set; }
        public virtual List<ProyectoUsuario> ProyectosUsuarios { get; set; }
        public virtual List<Publicacion> Publicaciones { get; set; }
        public virtual List<RegistroPropiedad> RegistroPropiedades { get; set; }
        public virtual List<Premio> Premios { get; set; }
        public virtual List<ParticipacionEvento> Participacioneventos { get; set; }
        public virtual List<Resultado> Resultados { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<CentroTrabajo> CentroTrabajos { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Asignatura> Asignaturas { get; set; }
        public virtual DbSet<Asignaturasimparte> Asignaturasimparte { get; set; }
        public virtual DbSet<Maestria> Maestrias { get; set; }
        public virtual DbSet<MaestriaUsuario> MaestriaUsuarios { get; set; }
        public virtual DbSet<Cursorecibido> Cursorecibidos { get; set; }
        public virtual DbSet<CursoImpartido> CursosImpartidos { get; set; }
        public virtual DbSet<Condecoracion> Condecoraciones { get; set; }
        public virtual DbSet<Proyecto> Proyectos { get; set; }
        public virtual DbSet<ProyectoUsuario> ProyectosUsuarios { get; set; }
        public virtual DbSet<Publicacion> Publicaciones { get; set; }
        public virtual DbSet<RegistroPropiedad> RegistroPropiedades { get; set; }
        public virtual DbSet<Premio> Premios { get; set; }
        public virtual DbSet<Evento> Eventos { get; set; }
        public virtual DbSet<ParticipacionEvento> ParticipacionEventos { get; set; }
        public virtual DbSet<Resultado> Resultados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public System.Data.Entity.DbSet<ProdCientifica.Models.ApplicationUser> ApplicationUsers { get; set; }

    }
}