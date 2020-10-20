using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskRobo.Models
{
    public class UserTask
    {
        [Key]
        public int TaskId { get; set; }
        public string TaskTitle { get; set; }
        public string TaskContent { get; set; }
        public string TaskStatus { get; set; }


        [ForeignKey("UserID")]
        public AppUser AppUsers { get; set; }
        public string UserID { get; set; }


        [ForeignKey("CategoryID")]
        public Category catogories { get; set; }
        public int CategoryID { get; set; }
    }
}
