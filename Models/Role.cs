using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAPI.Models
{
    public class Role
    {
        public long Id { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
