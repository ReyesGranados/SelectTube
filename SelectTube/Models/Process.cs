using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SelectTube.Models
{
    public enum ProcessStatus
    {
        Borrador,
        Reclutando,
        Finalizado
    }

    public class Process
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public DateTime FechaComienzo { get; set; }

        [Required]
        public DateTime FechaFinalizacion { get; set; }

        [Required]
        public ProcessStatus Estado { get; set; }

        public List<ProcessCandidate> ProcessCandidates { get; set; } = new List<ProcessCandidate>();
    }
}
