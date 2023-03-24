using System.ComponentModel.DataAnnotations;

namespace SelectTube.Models
{
    public class Recruiter
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
