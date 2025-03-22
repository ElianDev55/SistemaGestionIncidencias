using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaGestionIncidencias.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public bool EsTecnico { get; set; } // Define si el usuario es un técnico o no

        public virtual ICollection<Incidencia> IncidenciasReportadas { get; set; }
        public virtual ICollection<Incidencia> IncidenciasAsignadas { get; set; }
    }
}
