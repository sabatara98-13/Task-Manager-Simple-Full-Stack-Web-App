using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using saba_final_task_backend.Data;
using saba_final_task_backend.Models;

namespace saba_final_task_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly AppDbContext _context;

    public TasksController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskItem>>> GetAll()
    {
        var tasks = await _context.Tasks.ToListAsync();
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TaskItem>> GetById(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }

    [HttpPost]
    public async Task<ActionResult<TaskItem>> Create([FromBody] TaskItem task)
    {
        task.Id = 0;
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] TaskItem updatedTask)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null)
        {
            return NotFound();
        }

        task.Title = updatedTask.Title;
        task.Priority = updatedTask.Priority;
        task.IsDone = updatedTask.IsDone;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
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
