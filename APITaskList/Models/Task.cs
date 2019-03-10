using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITaskList.Models
{
    public class Task
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public DateTime Create_At { get; set; }
        public DateTime Update_At { get; set; }
        public DateTime Delete_At { get; set; }
        public DateTime Done_At { get; set; }
    }
}
