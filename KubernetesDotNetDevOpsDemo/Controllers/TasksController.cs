using Microsoft.AspNetCore.Mvc;

namespace KubernetesDotNetDevOpsDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private static readonly List<TaskItem> _tasks = new();

    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }

    [HttpGet]
    public ActionResult<IEnumerable<TaskItem>> GetAll()
    {
        return Ok(_tasks);
    }

    [HttpPost]
    public ActionResult<TaskItem> Create([FromBody] TaskItem task)
    {
        task.Id = _tasks.Count + 1;
        _tasks.Add(task);
        return CreatedAtAction(nameof(GetAll), new { id = task.Id }, task);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) return NotFound();
        _tasks.Remove(task);
        return NoContent();
    }
}