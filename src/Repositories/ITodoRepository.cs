using TodoListApi.DTO;
using TodoListApi.Models;

namespace TodoListApi.Repositories;
// Interface untuk Repository Todo
public interface ITodoRepository
{
    Task<IEnumerable<Todo>> GetAllTodosAsync();
    Task<Todo?> GetTodoByIdAsync(Guid id);
    Task<Todo?> CreateTodoAsync(Todo todo);
    Task UpdateTodoAsync(Todo todo);
    Task DeleteTodoAsync(Todo todo);
}
