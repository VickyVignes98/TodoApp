using Microsoft.EntityFrameworkCore;
using Todo.Application.Interfaces;
using Todo.Core.Entities;
using Todo.Infrastructure.Data;

namespace Todo.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _db;
        public TodoRepository(TodoDbContext db) { _db = db; }

        public async Task<TodoItem> AddAsync(TodoItem item)
        {
            _db.TodoItems.Add(item);
            await _db.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(int id)
        {
            var e = await _db.TodoItems.FindAsync(id);
            if (e != null) { _db.TodoItems.Remove(e); await _db.SaveChangesAsync(); }
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync() => await _db.TodoItems.AsNoTracking().ToListAsync();

        public async Task<TodoItem?> GetByIdAsync(int id) => await _db.TodoItems.FindAsync(id);

        public async Task UpdateAsync(TodoItem item)
        {
            _db.TodoItems.Update(item);
            await _db.SaveChangesAsync();
        }
    }
}
