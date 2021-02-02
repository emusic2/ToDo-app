using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskModel = ToDoAPI.Models.Task;

namespace ToDoAPI.Data
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> SearchByName(string Name);
    }
}
