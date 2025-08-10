using Todo.Application.DTOs;
using Todo.Application.Interfaces;
using Todo.Core.Entities;

namespace Todo.Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repo;
        public TodoService(ITodoRepository repo) { _repo = repo; }

        public async Task<TodoDto> CreateAsync(TodoCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
                throw new ArgumentException("Title is required", nameof(dto.Title));

            var entity = new TodoItem
            {
                Title = dto.Title.Trim(),
                Description = dto.Description,
                IsCompleted = false
            };

            var added = await _repo.AddAsync(entity);
            return Map(added);
        }

        public async Task<IEnumerable<TodoDto>> GetAllAsync()
            => (await _repo.GetAllAsync()).Select(Map);

        public async Task<TodoDto?> GetByIdAsync(int id)
        {
            var e = await _repo.GetByIdAsync(id);
            return e == null ? null : Map(e);
        }

        public async Task<bool> UpdateAsync(int id, TodoCreateDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;
            if (string.IsNullOrWhiteSpace(dto.Title))
                throw new ArgumentException("Title is required", nameof(dto.Title));
            existing.Title = dto.Title.Trim();
            existing.Description = dto.Description;
            await _repo.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;
            await _repo.DeleteAsync(id);
            return true;
        }

        private static TodoDto Map(TodoItem e) =>
            new TodoDto { Id = e.Id, Title = e.Title, Description = e.Description, IsCompleted = e.IsCompleted, CreatedAt = e.CreatedAt };
    }
}
