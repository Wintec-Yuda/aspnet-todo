using TodoListApi.DTO;
using TodoListApi.Models;

namespace TodoListApi.Services;
public interface ITodoService
{
  Task<IEnumerable<Todo>> GetAllTodos();
  Task<Todo?> GetTodoById(Guid id);
  Task<Todo?> CreateTodo(TodoRequestDTO todo);
  Task UpdateTodo(Guid id, TodoRequestDTO todo);
  Task DeleteTodo(Guid id);
  Task<IEnumerable<TodoResponseDTO>> GetTodosByUserId(Guid userId);
}
