using System.ComponentModel.DataAnnotations;

namespace SelectTube.Models
{
    public class User
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
