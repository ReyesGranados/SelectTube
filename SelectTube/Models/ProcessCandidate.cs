using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace SelectTube.Models
{
    public class ProcessCandidate
    {
        public int Id { get; set; }

        [Required]
        public Candidate Candidate { get; set; }

        [Required]
        public Process Process { get; set; }

        [Required]
        public DateTime DateIncluded { get; set; }

        [Required]
        public CandidateStatus Status { get; set; }
    }

}

