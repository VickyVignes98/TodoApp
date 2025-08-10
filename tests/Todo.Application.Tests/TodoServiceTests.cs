using Moq;
using Todo.Application.Interfaces;
using Todo.Application.Services;
using Todo.Application.DTOs;
using Todo.Core.Entities;
using Xunit;

namespace Todo.Application.Tests
{
    public class TodoServiceTests
    {
        [Fact]
        public async Task CreateAsync_WithEmptyTitle_ThrowsArgumentException()
        {
            var repo = new Mock<ITodoRepository>();
            var svc = new TodoService(repo.Object);

            var dto = new TodoCreateDto { Title = "", Description = "x" };

            await Assert.ThrowsAsync<ArgumentException>(() => svc.CreateAsync(dto));
        }

        [Fact]
        public async Task CreateAsync_Valid_CallsRepoAddAndReturnsDto()
        {
            var repo = new Mock<ITodoRepository>();
            repo.Setup(r => r.AddAsync(It.IsAny<TodoItem>()))
                .ReturnsAsync((TodoItem i) => { i.Id = 1; return i; });

            var svc = new TodoService(repo.Object);
            var outDto = await svc.CreateAsync(new TodoCreateDto { Title = "Test", Description = "d" });

            Assert.Equal(1, outDto.Id);
            Assert.Equal("Test", outDto.Title);
            repo.Verify(r => r.AddAsync(It.IsAny<TodoItem>()), Times.Once);
        }
    }
}
