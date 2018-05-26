namespace ProdCientifica.Migrations.Identity
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class act2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cursorecibido", "nivel", c => c.Int(nullable: false));
            AddColumn("dbo.CursoImpartido", "nivel", c => c.Int(nullable: false));
            AddColumn("dbo.CursoImpartido", "Descripcion", c => c.String(maxLength: 255));
            AlterColumn("dbo.Cursorecibido", "Tipo", c => c.Int(nullable: false));
            AlterColumn("dbo.CursoImpartido", "Tipo", c => c.Int(nullable: false));
            DropColumn("dbo.Cursorecibido", "Caracter");
            DropColumn("dbo.CursoImpartido", "Caracter");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CursoImpartido", "Caracter", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Cursorecibido", "Caracter", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.CursoImpartido", "Tipo", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Cursorecibido", "Tipo", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.CursoImpartido", "Descripcion");
            DropColumn("dbo.CursoImpartido", "nivel");
            DropColumn("dbo.Cursorecibido", "nivel");
        }
    }
}
