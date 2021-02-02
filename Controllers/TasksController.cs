using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Data;
using ToDoAPI.Models;
using Task = ToDoAPI.Models.Task;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskContext _context;
        private readonly ITaskRepository _taskRepository;

        public TasksController(TaskContext context, ITaskRepository taskRepository)
        {
            _context = context;
            context.Database.EnsureCreated();
            _taskRepository = taskRepository;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Task>>> GetTasks(String search)
        {
            if(!String.IsNullOrEmpty(search))
            {
               return await _taskRepository.SearchByName(search);
            }
            return await _context.Tasks.ToListAsync();
        }

        // GET: api/Tasks/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Task>> GetTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutTask(long id, Task task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Task>> PostTask(Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { id = task.Id }, task);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Task>> DeleteTask(long id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return task;
        }

        private bool TaskExists(long id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
