using TodoListApi.DTO;
using TodoListApi.Models;

namespace TodoListApi.Repositories;
// Interface untuk Repository Todo
public interface ITodoRepository
{
    Task<IEnumerable<Todo>> GetAllTodos();
    Task<Todo?> GetTodoById(Guid id);
    Task<Todo?> CreateTodo(Todo todo);
    Task UpdateTodo(Todo todo);
    Task DeleteTodo(Todo todo);
    Task<IEnumerable<TodoResponseDTO>> GetTodosByUserId(Guid userId);
}
