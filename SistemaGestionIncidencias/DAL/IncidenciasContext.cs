using System.Data.Entity;
using SistemaGestionIncidencias.Models; // Asegúrate de usar el namespace correcto

namespace SistemaGestionIncidencias.DAL
{
    public class IncidenciasContext : DbContext
    {
        public IncidenciasContext() : base("IncidenciasDB")
        {
        }

        public DbSet<Incidencia> Incidencias { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


    }
}
