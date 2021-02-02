using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("Role")]
        public int RoleID { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}
