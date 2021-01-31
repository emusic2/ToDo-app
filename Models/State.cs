using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAPI.Models
{
    public class State
    {
        public long Id { get; set; }

        [Required]
        public string StateName { get; set; }
    }
}
