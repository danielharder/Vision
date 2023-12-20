using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vision.Server.DTO.CreateDTOs;
using Vision.Server.Models;

namespace Vision.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly VisionDbContext _context;

        public TaskController(VisionDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetAllTasks")]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetAllTasks()
        {
            var tasks = await _context.Tasks.ToListAsync();
            var taskDTOs = tasks.Select(task => new TaskDTO
            {
                PK = task.PK,
                StoryID = task.StoryPK,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status
            }).ToList();

            return Ok(taskDTOs);
        }

        [HttpGet("{id}", Name = "GetTaskById")]
        public async Task<ActionResult<TaskDTO>> GetTask(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            var taskDTO = new TaskDTO
            {
                PK = task.PK,
                StoryID = task.StoryPK,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status
            };

            return taskDTO;
        }

        [HttpPost(Name = "CreateTask")]
        public async Task<ActionResult<TaskDTO>> CreateTask(CreateTaskDTO taskDTO)
        {
            var task = new TaskEntity
            {
                Title = taskDTO.Title,
                Description = taskDTO.Description,
                Status = taskDTO.Status,
                CreationDate = DateTime.Now,
                ArchiveDate = DateTime.MaxValue,
                StoryPK = taskDTO.StoryID
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return await GetTask(task.PK);
        }

        [HttpPut("{id}", Name = "UpdateTask")]
        public async Task<ActionResult> UpdateTask(Guid id, CreateTaskDTO taskDTO)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            task.Title = taskDTO.Title;
            task.Description = taskDTO.Description;
            task.Status = taskDTO.Status;

            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteTask")]
        public async Task<ActionResult> DeleteTask(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
