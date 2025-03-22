namespace SistemaGestionIncidencias.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarUsuariosRelacion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false),
                        EsTecnico = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Incidencias", "UsuarioReportaId", c => c.Int(nullable: false));
            AddColumn("dbo.Incidencias", "TecnicoAsignadoId", c => c.Int());
            AddColumn("dbo.Incidencias", "Usuario_Id", c => c.Int());
            AddColumn("dbo.Incidencias", "Usuario_Id1", c => c.Int());
            CreateIndex("dbo.Incidencias", "UsuarioReportaId");
            CreateIndex("dbo.Incidencias", "TecnicoAsignadoId");
            CreateIndex("dbo.Incidencias", "Usuario_Id");
            CreateIndex("dbo.Incidencias", "Usuario_Id1");
            AddForeignKey("dbo.Incidencias", "Usuario_Id", "dbo.Usuarios", "Id");
            AddForeignKey("dbo.Incidencias", "Usuario_Id1", "dbo.Usuarios", "Id");
            AddForeignKey("dbo.Incidencias", "TecnicoAsignadoId", "dbo.Usuarios", "Id");
            AddForeignKey("dbo.Incidencias", "UsuarioReportaId", "dbo.Usuarios", "Id", cascadeDelete: true);
            DropColumn("dbo.Incidencias", "UsuarioReporta");
            DropColumn("dbo.Incidencias", "TecnicoAsignado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Incidencias", "TecnicoAsignado", c => c.String());
            AddColumn("dbo.Incidencias", "UsuarioReporta", c => c.String(nullable: false));
            DropForeignKey("dbo.Incidencias", "UsuarioReportaId", "dbo.Usuarios");
            DropForeignKey("dbo.Incidencias", "TecnicoAsignadoId", "dbo.Usuarios");
            DropForeignKey("dbo.Incidencias", "Usuario_Id1", "dbo.Usuarios");
            DropForeignKey("dbo.Incidencias", "Usuario_Id", "dbo.Usuarios");
            DropIndex("dbo.Incidencias", new[] { "Usuario_Id1" });
            DropIndex("dbo.Incidencias", new[] { "Usuario_Id" });
            DropIndex("dbo.Incidencias", new[] { "TecnicoAsignadoId" });
            DropIndex("dbo.Incidencias", new[] { "UsuarioReportaId" });
            DropColumn("dbo.Incidencias", "Usuario_Id1");
            DropColumn("dbo.Incidencias", "Usuario_Id");
            DropColumn("dbo.Incidencias", "TecnicoAsignadoId");
            DropColumn("dbo.Incidencias", "UsuarioReportaId");
            DropTable("dbo.Usuarios");
        }
    }
}
