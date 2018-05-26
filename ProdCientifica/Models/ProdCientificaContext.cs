namespace ProdCientifica.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class ProdCientificaContext : DbContext
    {
        // Your context has been configured to use a 'ProdCientificaContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ProdCientifica.Models.ProdCientificaContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ProdCientificaContext' 
        // connection string in the application configuration file.
        public ProdCientificaContext()
            : base("name=ProdCientificaContext")
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
            /*modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();*/
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
//public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

// Add a DbSet for each entity type that you want to include in your model. For more information 
// on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

// public virtual DbSet<MyEntity> MyEntities { get; set; }
}

//public class MyEntity
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//}
}
 