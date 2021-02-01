using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;

namespace ToDoAPI.Models
{
    public class TaskContext: IdentityDbContext<User, Role, Guid>
    {
        public TaskContext(DbContextOptions<TaskContext> options): base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Task>().HasOne(i => i.State).WithMany(b => b.Tasks);
            //modelBuilder.Entity<State>().HasMany(b => b.Tasks).WithOne(i => i.State); 

            //modelBuilder.Entity<Role>().HasData(
            //   new Role { Id = 1, Name = "Admin" },
            //   new Role { Id = 2, Name = "Standard" }
            //   );

            //modelBuilder.Entity<User>().HasData(
            //    new User { Id = 1, Name = "admin", Email = "admin@maus.ba", Password = "Testpass1", RoleID = 1, Active = true }
            //);

            var FirstState = new Models.State
            {
                Id = 1,
                Name = "Not started"
            };

            modelBuilder.Entity<State>(s =>
            {
                s.HasData(FirstState);
            });

            var NormalTag = new Models.Tag
            {
                Id = 1,
                Name = "Normal"
            };

            modelBuilder.Entity<Tag>(t =>
            {
                t.HasData(FirstState);
            });

            DateTime aDate = DateTime.Now;

            modelBuilder.Entity<Task>().HasData(
                new Task { Id = 1, Name = "Task 1", StateId = FirstState.Id, TagId = NormalTag.Id, LiveTimeSpent = aDate.ToString("HH:mm")}
            );
            modelBuilder.Entity<Task>().HasData(
                new Task { Id = 2, Name = "Task 2", StateId = FirstState.Id, TagId = NormalTag.Id, LiveTimeSpent = aDate.ToString("HH:mm") }
            );
            modelBuilder.Entity<Task>().HasData(
                new Task { Id = 3, Name = "Task 3", StateId = FirstState.Id, TagId = NormalTag.Id, LiveTimeSpent = aDate.ToString("HH:mm") }
            );
            modelBuilder.Entity<Task>().HasData(
                new Task { Id = 4, Name = "Task 4", StateId = FirstState.Id, TagId = NormalTag.Id, LiveTimeSpent = aDate.ToString("HH:mm") }
            );
            modelBuilder.Entity<Task>().HasData(
                new Task { Id = 5, Name = "Task 5", StateId = FirstState.Id, TagId = NormalTag.Id, LiveTimeSpent = aDate.ToString("HH:mm") }
            );
            modelBuilder.Entity<Task>().HasData(
                new Task { Id = 6, Name = "Task 6", StateId = FirstState.Id, TagId = NormalTag.Id, LiveTimeSpent = aDate.ToString("HH:mm") }
            );
        }
    }
}
