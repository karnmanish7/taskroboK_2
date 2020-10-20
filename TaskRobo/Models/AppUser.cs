using System.ComponentModel.DataAnnotations;

namespace TaskRobo.Models
{
    public class AppUser
    {
        [Key]
        public string UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
