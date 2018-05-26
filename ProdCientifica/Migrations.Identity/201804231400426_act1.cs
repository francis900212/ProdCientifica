namespace ProdCientifica.Migrations.Identity
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class act1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asignatura",
                c => new
                    {
                        AsignaturaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.AsignaturaId);
            
            CreateTable(
                "dbo.Asignaturasimparte",
                c => new
                    {
                        AsignaturasimparteId = c.Int(nullable: false, identity: true),
                        AsignaturaId = c.Int(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AsignaturasimparteId)
                .ForeignKey("dbo.Asignatura", t => t.AsignaturaId)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.AsignaturaId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(maxLength: 50),
                        Sexo = c.Int(nullable: false),
                        Ci = c.Int(nullable: false),
                        TituloGraduado = c.Int(),
                        CategoriaDocente = c.Int(),
                        AnnoInicioDocente = c.DateTime(),
                        UltimaEvaluacionDocente = c.Int(),
                        ProfesorConsultante = c.Boolean(nullable: false),
                        CategoriaInvestigativa = c.Int(),
                        AnnoCategoriaInvestigativa = c.DateTime(),
                        GradoCientifico = c.Int(),
                        HonorisCausa = c.Boolean(nullable: false),
                        ProfesorMerito = c.Boolean(nullable: false),
                        PerteneceAlClaustro = c.Boolean(nullable: false),
                        Especialista1erGrado = c.String(maxLength: 100),
                        Especialista2doGrado = c.String(maxLength: 100),
                        Path = c.String(),
                        DepartamentoId = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departamento", t => t.DepartamentoId)
                .Index(t => t.DepartamentoId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Condecoracion",
                c => new
                    {
                        CondecoracionId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(maxLength: 255),
                        Date = c.DateTime(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CondecoracionId)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Cursorecibido",
                c => new
                    {
                        CursorecibidoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Tipo = c.String(nullable: false, maxLength: 50),
                        Caracter = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(maxLength: 255),
                        Fecha = c.DateTime(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CursorecibidoId)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.CursoImpartido",
                c => new
                    {
                        CursoimpartidoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        ProfesorPrincipal = c.Boolean(nullable: false),
                        Tipo = c.String(nullable: false, maxLength: 50),
                        Caracter = c.String(nullable: false, maxLength: 50),
                        Fecha = c.DateTime(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CursoimpartidoId)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Departamento",
                c => new
                    {
                        DepartamentoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(maxLength: 255),
                        CentroTrabajoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartamentoId)
                .ForeignKey("dbo.CentroTrabajo", t => t.CentroTrabajoId)
                .Index(t => t.CentroTrabajoId);
            
            CreateTable(
                "dbo.CentroTrabajo",
                c => new
                    {
                        CentroTrabajoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Direccion = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.CentroTrabajoId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MaestriaUsuario",
                c => new
                    {
                        MaestriaUsuarioId = c.Int(nullable: false, identity: true),
                        FechaAdquiriolaMaestria = c.DateTime(nullable: false),
                        LugarAdquiriolaMaestria = c.String(maxLength: 255),
                        MaestriaId = c.Int(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MaestriaUsuarioId)
                .ForeignKey("dbo.Maestria", t => t.MaestriaId)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.MaestriaId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Maestria",
                c => new
                    {
                        MaestriaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.MaestriaId);
            
            CreateTable(
                "dbo.ParticipacionEvento",
                c => new
                    {
                        ParticipacioneventoId = c.Int(nullable: false, identity: true),
                        ParticipoComo = c.String(nullable: false, maxLength: 255),
                        Titulo = c.String(maxLength: 255),
                        EventoId = c.Int(nullable: false),
                        ProyectoId = c.Int(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ParticipacioneventoId)
                .ForeignKey("dbo.Evento", t => t.EventoId)
                .ForeignKey("dbo.Proyecto", t => t.ProyectoId)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.EventoId)
                .Index(t => t.ProyectoId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Evento",
                c => new
                    {
                        EventoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(maxLength: 255),
                        Nivel = c.String(nullable: false, maxLength: 255),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EventoId);
            
            CreateTable(
                "dbo.Proyecto",
                c => new
                    {
                        ProyectoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 255),
                        Descripcion = c.String(nullable: false, maxLength: 255),
                        Nivel = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ProyectoId);
            
            CreateTable(
                "dbo.Premio",
                c => new
                    {
                        PremioId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        ConvocadoPor = c.String(maxLength: 50),
                        Nivel = c.String(nullable: false, maxLength: 50),
                        Fecha = c.DateTime(nullable: false),
                        ProyectoId = c.Int(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PremioId)
                .ForeignKey("dbo.Proyecto", t => t.ProyectoId)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.ProyectoId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.ProyectoUsuario",
                c => new
                    {
                        ProyectoUsuarioId = c.Int(nullable: false, identity: true),
                        Participacomo = c.String(nullable: false, maxLength: 50),
                        ProyectoId = c.Int(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ProyectoUsuarioId)
                .ForeignKey("dbo.Proyecto", t => t.ProyectoId)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.ProyectoId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Publicacion",
                c => new
                    {
                        PublicacionId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Nivel = c.String(nullable: false, maxLength: 50),
                        Registro = c.String(nullable: false, maxLength: 50),
                        Espesificaciones = c.String(maxLength: 50),
                        PublicadoEnSitio = c.String(nullable: false, maxLength: 100),
                        UrlSitio = c.String(nullable: false, maxLength: 255),
                        Fecha = c.DateTime(nullable: false),
                        PublicaComo = c.String(nullable: false, maxLength: 50),
                        Categoria = c.String(maxLength: 50),
                        ProyectoId = c.Int(),
                        UsuarioId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PublicacionId)
                .ForeignKey("dbo.Proyecto", t => t.ProyectoId)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.ProyectoId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.RegistroPropiedad",
                c => new
                    {
                        RegistropropiedadId = c.Int(nullable: false, identity: true),
                        RegistroNumber = c.String(nullable: false, maxLength: 255),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Tipo = c.String(nullable: false, maxLength: 50),
                        Modalidad = c.String(nullable: false, maxLength: 50),
                        Fecha = c.DateTime(nullable: false),
                        ProyectoId = c.Int(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RegistropropiedadId)
                .ForeignKey("dbo.Proyecto", t => t.ProyectoId)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.ProyectoId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Resultado",
                c => new
                    {
                        ResultadoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Participacomo = c.String(nullable: false, maxLength: 50),
                        Detalles = c.String(nullable: false, maxLength: 255),
                        Fecha = c.DateTime(nullable: false),
                        ProyectoId = c.Int(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ResultadoId)
                .ForeignKey("dbo.Proyecto", t => t.ProyectoId)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.ProyectoId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ParticipacionEvento", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Resultado", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Resultado", "ProyectoId", "dbo.Proyecto");
            DropForeignKey("dbo.RegistroPropiedad", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RegistroPropiedad", "ProyectoId", "dbo.Proyecto");
            DropForeignKey("dbo.Publicacion", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Publicacion", "ProyectoId", "dbo.Proyecto");
            DropForeignKey("dbo.ProyectoUsuario", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProyectoUsuario", "ProyectoId", "dbo.Proyecto");
            DropForeignKey("dbo.Premio", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Premio", "ProyectoId", "dbo.Proyecto");
            DropForeignKey("dbo.ParticipacionEvento", "ProyectoId", "dbo.Proyecto");
            DropForeignKey("dbo.ParticipacionEvento", "EventoId", "dbo.Evento");
            DropForeignKey("dbo.MaestriaUsuario", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MaestriaUsuario", "MaestriaId", "dbo.Maestria");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Departamento", "CentroTrabajoId", "dbo.CentroTrabajo");
            DropForeignKey("dbo.AspNetUsers", "DepartamentoId", "dbo.Departamento");
            DropForeignKey("dbo.CursoImpartido", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cursorecibido", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Condecoracion", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Asignaturasimparte", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Asignaturasimparte", "AsignaturaId", "dbo.Asignatura");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Resultado", new[] { "UsuarioId" });
            DropIndex("dbo.Resultado", new[] { "ProyectoId" });
            DropIndex("dbo.RegistroPropiedad", new[] { "UsuarioId" });
            DropIndex("dbo.RegistroPropiedad", new[] { "ProyectoId" });
            DropIndex("dbo.Publicacion", new[] { "UsuarioId" });
            DropIndex("dbo.Publicacion", new[] { "ProyectoId" });
            DropIndex("dbo.ProyectoUsuario", new[] { "UsuarioId" });
            DropIndex("dbo.ProyectoUsuario", new[] { "ProyectoId" });
            DropIndex("dbo.Premio", new[] { "UsuarioId" });
            DropIndex("dbo.Premio", new[] { "ProyectoId" });
            DropIndex("dbo.ParticipacionEvento", new[] { "UsuarioId" });
            DropIndex("dbo.ParticipacionEvento", new[] { "ProyectoId" });
            DropIndex("dbo.ParticipacionEvento", new[] { "EventoId" });
            DropIndex("dbo.MaestriaUsuario", new[] { "UsuarioId" });
            DropIndex("dbo.MaestriaUsuario", new[] { "MaestriaId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Departamento", new[] { "CentroTrabajoId" });
            DropIndex("dbo.CursoImpartido", new[] { "UsuarioId" });
            DropIndex("dbo.Cursorecibido", new[] { "UsuarioId" });
            DropIndex("dbo.Condecoracion", new[] { "UsuarioId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "DepartamentoId" });
            DropIndex("dbo.Asignaturasimparte", new[] { "UsuarioId" });
            DropIndex("dbo.Asignaturasimparte", new[] { "AsignaturaId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Resultado");
            DropTable("dbo.RegistroPropiedad");
            DropTable("dbo.Publicacion");
            DropTable("dbo.ProyectoUsuario");
            DropTable("dbo.Premio");
            DropTable("dbo.Proyecto");
            DropTable("dbo.Evento");
            DropTable("dbo.ParticipacionEvento");
            DropTable("dbo.Maestria");
            DropTable("dbo.MaestriaUsuario");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.CentroTrabajo");
            DropTable("dbo.Departamento");
            DropTable("dbo.CursoImpartido");
            DropTable("dbo.Cursorecibido");
            DropTable("dbo.Condecoracion");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Asignaturasimparte");
            DropTable("dbo.Asignatura");
        }
    }
}
