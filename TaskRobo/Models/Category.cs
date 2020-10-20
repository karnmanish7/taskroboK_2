using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskRobo.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryTitle { get; set; }

        [ForeignKey("UserID")]
        public AppUser AppUsers { get; set; }
        public string UserID { get; set; }
    }
}
