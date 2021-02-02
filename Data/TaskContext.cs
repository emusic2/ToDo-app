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

        public DbSet<TagsTasks> TagTask { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
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
                t.HasData(NormalTag);
            });

            modelBuilder.Entity<TagsTasks>()
            .HasKey(bc => new { bc.TagId, bc.TaskId });

            modelBuilder.Entity<TagsTasks>()
                .HasOne(bc => bc.Tag)
                .WithMany(b => b.Tasks)
                .HasForeignKey(bc => bc.TagId);

            modelBuilder.Entity<TagsTasks>()
                .HasOne(bc => bc.Task)
                .WithMany(c => c.Tags)
                .HasForeignKey(bc => bc.TaskId);

            modelBuilder.Entity<TagsTasks>().HasData(
              new TagsTasks { TagId = 1, TaskId = 1 }
             );
            modelBuilder.Entity<TagsTasks>().HasData(
              new TagsTasks { TagId = 1, TaskId = 2 }
             );
            modelBuilder.Entity<TagsTasks>().HasData(
              new TagsTasks { TagId = 1, TaskId = 3 }
             );

            modelBuilder.Entity<Task>().HasData(
                new Task { Id = 1, Name = "Task 1", StateId = FirstState.Id, LiveTimeSpent = "00:00" }
            );
            modelBuilder.Entity<Task>().HasData(
                new Task { Id = 2, Name = "Task 2", StateId = FirstState.Id, LiveTimeSpent = "00:00" }
            );
            modelBuilder.Entity<Task>().HasData(
                new Task { Id = 3, Name = "Task 3", StateId = FirstState.Id, LiveTimeSpent = "00:00" }
            );
            modelBuilder.Entity<Task>().HasData(
                new Task { Id = 4, Name = "Task 4", StateId = FirstState.Id, LiveTimeSpent = "00:00" }
            );
            modelBuilder.Entity<Task>().HasData(
                new Task { Id = 5, Name = "Task 5", StateId = FirstState.Id, LiveTimeSpent = "00:00" }
            );
            modelBuilder.Entity<Task>().HasData(
                new Task { Id = 6, Name = "Task 6", StateId = FirstState.Id, LiveTimeSpent = "00:00" }
            );
            
        }
    }
}
