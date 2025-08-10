using Todo.Application.DTOs;

namespace Todo.Application.Services
{
    public interface ITodoService
    {
        Task<TodoDto> CreateAsync(TodoCreateDto dto);
        Task<IEnumerable<TodoDto>> GetAllAsync();
        Task<TodoDto?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, TodoCreateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
