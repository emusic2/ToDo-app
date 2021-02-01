using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ToDoAPI.Models
{
    public class User: IdentityUser<Guid>
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int RoleID { get; set; }

        public Role Role { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
