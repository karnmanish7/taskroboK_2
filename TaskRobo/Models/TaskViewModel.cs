using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskRobo.Models
{
    public class TaskViewModel
    {

        public int TaskId { get; set; }
        public string TaskTitle { get; set; }
        public string TaskContent { get; set; }
        public string TaskStatus { get; set; }

        public int CategoryID { get; set; }

        public List<Category> Catogories { get; set; }

    }
}