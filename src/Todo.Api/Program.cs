using Microsoft.EntityFrameworkCore;
using Todo.Application.Interfaces;
using Todo.Application.Services;
using Todo.Infrastructure.Data;
using Todo.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conn = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=todo.db";
builder.Services.AddDbContext<TodoDbContext>(options => options.UseSqlite(conn));

builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<ITodoService, TodoService>();

builder.Services.AddCors(options => options.AddPolicy("AllowLocal", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowLocal");
app.UseAuthorization();
app.MapControllers();
app.Run();
