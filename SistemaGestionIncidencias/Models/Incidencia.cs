using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestionIncidencias.Models
{
    public class Incidencia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Titulo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string Estado { get; set; } // Abierta, En Progreso, Resuelta, Cerrada

        [Required]
        public string Prioridad { get; set; } // Baja, Media, Alta, Crítica

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime FechaActualizacion { get; set; } = DateTime.Now;

        // Relación con Usuario que Reporta
        [Required]
        public int UsuarioReportaId { get; set; }

        [ForeignKey("UsuarioReportaId")]
        public virtual Usuario UsuarioReporta { get; set; }

        // Relación con Técnico Asignado
        public int? TecnicoAsignadoId { get; set; } // Puede ser nulo si aún no hay técnico asignado

        [ForeignKey("TecnicoAsignadoId")]
        public virtual Usuario TecnicoAsignado { get; set; }
    }
}
