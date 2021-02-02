using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoAPI.Models;
using TaskModel = ToDoAPI.Models.Task;

namespace ToDoAPI.Data
{
    public class TaskRepository: ITaskRepository
    {
        private readonly TaskContext taskContext;

        public TaskRepository(TaskContext taskContext)
        {
            this.taskContext = taskContext;
        }

       
        async Task<List<TaskModel>> ITaskRepository.SearchByName(string Name)
        {
            IQueryable<TaskModel> query = taskContext.Tasks;

            if (!String.IsNullOrEmpty(Name))
            {
                query = query.Where(n => n.Name.Contains(Name, StringComparison.CurrentCultureIgnoreCase));
            }

            return await query.ToListAsync();
        }
    }
}
