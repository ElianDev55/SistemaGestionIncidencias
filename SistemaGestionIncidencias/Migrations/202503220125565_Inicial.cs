namespace SistemaGestionIncidencias.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Incidencias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 200),
                        Descripcion = c.String(nullable: false),
                        Estado = c.String(nullable: false),
                        Prioridad = c.String(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaActualizacion = c.DateTime(nullable: false),
                        UsuarioReporta = c.String(nullable: false),
                        TecnicoAsignado = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Incidencias");
        }
    }
}
