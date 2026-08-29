using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using saba_final_task_backend.Data;
using saba_final_task_backend.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddCors();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=tasks.db"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
    if (!db.Tasks.Any())
    {
        db.Tasks.AddRange(
            new TaskItem { Title = "Complete Web Development Capstone", Priority = "High", IsDone = false },
            new TaskItem { Title = "Buy groceries for dinner", Priority = "Medium", IsDone = false },
            new TaskItem { Title = "Review Session 19 notes", Priority = "Low", IsDone = true }
        );
        db.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.MapGet("/swagger", () => Results.Redirect("/scalar/v1"));
}

app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
