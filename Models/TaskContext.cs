using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;

namespace ToDoAPI.Models
{
    public class TaskContext: DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options): base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasData(
        //        new User { Id = 1, Name =  }
        //    );

        //}

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Task> Users { get; set; }
        public DbSet<Task> Roles { get; set; }
        public DbSet<Task> States { get; set; }
        public DbSet<Task> Tags { get; set; }
        public DbSet<ToDoAPI.Models.User> User { get; set; }
    }
}
