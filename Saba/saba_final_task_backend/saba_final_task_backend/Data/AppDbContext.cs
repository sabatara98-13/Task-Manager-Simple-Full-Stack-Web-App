using Microsoft.EntityFrameworkCore;
using saba_final_task_backend.Models;

namespace saba_final_task_backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<TaskItem> Tasks { get; set; } = null!;
}
