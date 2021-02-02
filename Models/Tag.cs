using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAPI.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        public ICollection<TagsTasks> Tasks { get; set; }
    }
}
