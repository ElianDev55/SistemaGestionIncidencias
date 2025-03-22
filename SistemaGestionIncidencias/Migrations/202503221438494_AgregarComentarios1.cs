namespace SistemaGestionIncidencias.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarComentarios1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comentarios", "Texto", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comentarios", "Texto", c => c.String(nullable: false, maxLength: 500));
        }
    }
}
