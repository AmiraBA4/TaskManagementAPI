using Microsoft.AspNetCore.Mvc;
using TaskManagement.Data;
using TaskManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TaskController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Retrieve Task list for the authenticated user
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("/user-tasks")]
        public async Task<ActionResult<IEnumerable<TaskModel>>> GetTasks()
        {
            // Obtenir l'ID de l'utilisateur authentifié
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Vérifier si l'ID de l'utilisateur est nul
            if (userId == null)
            {
                return Unauthorized();
            }

            // Récupérer les tâches associées à l'utilisateur authentifié
            var userTasks = await _context.Tasks
                 .Where(t => t.UserId.ToString() == "amira")
                 .Select(t => new TaskModel
                 {
                     Id = t.Id,
                     Title = t.Title,
                     Description = t.Description,
                     DueDate = t.DueDate,
                     IsCompleted = t.IsCompleted,
                     UserId = t.UserId
                 })
                .ToListAsync();

            return Ok(userTasks);
        }
        /// <summary>
        /// Retrieve a single Task by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetTaskById(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return task;
        }

        /// <summary>
        /// Create a new task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<TaskModel>> CreateTask(TaskModel task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, task);
        }

        /// <summary>
        /// Update an existing task
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedTask"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskModel updatedTask)
        {
            if (id != updatedTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(updatedTask).State = EntityState.Modified;

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

        /// <summary>
        /// Delete a task
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
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


        private bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }

    }

}



