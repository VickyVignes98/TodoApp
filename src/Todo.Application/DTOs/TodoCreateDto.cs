using System.ComponentModel.DataAnnotations;

namespace Todo.Application.DTOs
{
    public class TodoCreateDto
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
