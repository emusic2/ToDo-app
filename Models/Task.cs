using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoAPI.Models
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{HH:mm}")]
        public string LiveTimeSpent { get; set; }

        public ICollection<TagsTasks> Tags { get; set; }


    }
}
