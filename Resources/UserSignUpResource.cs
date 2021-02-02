using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAPI.Resources
{
    public class UserSignUpResource
    {
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
