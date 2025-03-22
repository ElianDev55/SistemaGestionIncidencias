namespace SistemaGestionIncidencias.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarComentarios : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comentarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Texto = c.String(nullable: false, maxLength: 500),
                        Fecha = c.DateTime(nullable: false),
                        IncidenciaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Incidencias", t => t.IncidenciaId, cascadeDelete: true)
                .Index(t => t.IncidenciaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comentarios", "IncidenciaId", "dbo.Incidencias");
            DropIndex("dbo.Comentarios", new[] { "IncidenciaId" });
            DropTable("dbo.Comentarios");
        }
    }
}
