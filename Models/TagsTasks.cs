using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAPI.Models
{
    public class TagsTasks
    {
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
