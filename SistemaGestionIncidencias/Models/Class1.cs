using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestionIncidencias.Models
{
    public class Comentario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Texto { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        [ForeignKey("Incidencia")]
        public int IncidenciaId { get; set; }

        public virtual Incidencia Incidencia { get; set; }
    }
}
