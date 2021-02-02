using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoAPI.Models;
using TaskModel = ToDoAPI.Models.Task;

namespace ToDoAPI.Data
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskContext taskContext;

        public TaskRepository(TaskContext taskContext)
        {
            this.taskContext = taskContext;
        }


        async Task<List<TaskModel>> ITaskRepository.FilterTasks(string Name, string TagIds)
        {
            IQueryable<TaskModel> query = taskContext.Tasks;

            if (!String.IsNullOrEmpty(TagIds))
            {
                int[] tagsId = TagIds.Split(',').Select(h => Int32.Parse(h)).ToArray();

                var tags = await taskContext.TagTask
                    .Where(x => tagsId.Contains(x.TagId))
                    .Select(x => x.TagId)
                    .Distinct()
                    .ToListAsync();

                query = taskContext.Tasks
                    .Include(x => x.Tags)
                    .Where(x => tags.Contains(x.Id));
            }

            if (!String.IsNullOrEmpty(Name))
            {
                query = query.Where(n => n.Name.Contains(Name, StringComparison.CurrentCultureIgnoreCase));
            }

          
            return await query.ToListAsync();
        }
    }
}
