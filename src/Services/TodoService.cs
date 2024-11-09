using TodoListApi.DTO;
using TodoListApi.Models;
using TodoListApi.Repositories;

namespace TodoListApi.Services;
public class TodoService : ITodoService
{
  private readonly ITodoRepository _todoRepository;
  private readonly IUserRepository _userRepository;

  public TodoService(ITodoRepository todoRepository, IUserRepository userRepository)
  {
    _todoRepository = todoRepository;
    _userRepository = userRepository;
  }
  public async Task<IEnumerable<Todo>> GetAllTodos()
  {
    return await _todoRepository.GetAllTodos();
  }
  public async Task<Todo?> GetTodoById(Guid id)
  {
    return await _todoRepository.GetTodoById(id);
  }
  public async Task<Todo?> CreateTodo(TodoRequestDTO todoDto)
  {
    var todo = new Todo
    {
      Title = todoDto.Title,
      Description = todoDto.Description,
      IsCompleted = todoDto.IsCompleted,
      UserId = todoDto.UserId
    };
    return await _todoRepository.CreateTodo(todo);
  }
  public async Task UpdateTodo(Guid id, TodoRequestDTO todoDto)
  {
    var todo = await _todoRepository.GetTodoById(id);
    if (todo == null)
    {
      throw new Exception("Todo not found");
    }

    todo.Title = todoDto.Title!;
    todo.Description = todoDto.Description!;
    todo.IsCompleted = todoDto.IsCompleted;
    await _todoRepository.UpdateTodo(todo);
  }
  public async Task DeleteTodo(Guid id)
  {
    var existingTodo = await _todoRepository.GetTodoById(id);
    if (existingTodo == null)
    {
      throw new Exception("Todo not found");
    }
    await _todoRepository.DeleteTodo(existingTodo);
  }
  public async Task<IEnumerable<TodoResponseDTO>> GetTodosByUserId(Guid userId)
  {
    var user = await _userRepository.GetUserById(userId);
    if (user == null)
    {
      throw new Exception("User not found");
    }
    return await _todoRepository.GetTodosByUserId(userId);
  }
}

