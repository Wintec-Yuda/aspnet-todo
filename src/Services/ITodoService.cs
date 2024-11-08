using TodoListApi.DTO;
using TodoListApi.Models;

namespace TodoListApi.Services;
public interface ITodoService
{
    Task<IEnumerable<Todo>> GetAllTodosAsync();
    Task<Todo?> GetTodoByIdAsync(Guid id);
    Task<Todo?> CreateTodoAsync(TodoRequestDTO todo);
    Task UpdateTodoAsync(Guid id, TodoRequestDTO todo);
    Task DeleteTodoAsync(Guid id);
}
