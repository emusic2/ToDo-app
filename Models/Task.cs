using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models
{
    public class Task
    {
        public long Id { get; set; }

        [Required]
        public string TaskName { get; set; }

        [Required]
        public State State { get; set; }

        [Required]
        public Tag Tag { get; set; }

        [DisplayFormat(DataFormatString = "{HH:mm}")]
        [Required]
        public DateTime LiveTimeSpent { get; set; }

    }
}
