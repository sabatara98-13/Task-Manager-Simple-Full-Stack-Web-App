using System.ComponentModel.DataAnnotations;

namespace saba_final_task_backend.Models;

public class TaskItem
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    public string Priority { get; set; } = "Medium";

    public bool IsDone { get; set; } = false;
}
