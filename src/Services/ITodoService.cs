using TodoListApi.DTO;
using TodoListApi.Models;

namespace TodoListApi.Services;
// Interface untuk Service Todo
public interface ITodoService
{
    Task<IEnumerable<Todo>> GetAllTodosAsync();
    Task<Todo?> GetTodoByIdAsync(Guid id);
    Task<Todo?> CreateTodoAsync(TodoCreateDTO todo);
    Task UpdateTodoAsync(Guid id, TodoUpdateDTO todo);
    Task DeleteTodoAsync(Guid id);
}
