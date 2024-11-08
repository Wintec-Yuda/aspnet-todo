using TodoListApi.DTO;
using TodoListApi.Models;
using TodoListApi.Repositories;

namespace TodoListApi.Services;
public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;

    public TodoService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<IEnumerable<Todo>> GetAllTodosAsync()
    {
        return await _todoRepository.GetAllTodosAsync();
    }
    public async Task<Todo?> GetTodoByIdAsync(Guid id)
    {
        return await _todoRepository.GetTodoByIdAsync(id);
    }
    public async Task<Todo?> CreateTodoAsync(TodoRequestDTO todoDto)
    {
        var todo = new Todo
        {
            Title = todoDto.Title,
            Description = todoDto.Description,
            IsCompleted = todoDto.IsCompleted
        };
        return await _todoRepository.CreateTodoAsync(todo);
    }
    public async Task UpdateTodoAsync(Guid id, TodoRequestDTO todoDto)
    {
        var todo = await _todoRepository.GetTodoByIdAsync(id);
        if (todo == null)
        {
            throw new Exception("Todo not found");
        }

        todo.Title = todoDto.Title!;
        todo.Description = todoDto.Description!;
        todo.IsCompleted = todoDto.IsCompleted;
        await _todoRepository.UpdateTodoAsync(todo);
    }
    public async Task DeleteTodoAsync(Guid id)
    {
        var existingTodo = await _todoRepository.GetTodoByIdAsync(id);
        if (existingTodo == null)
        {
            throw new Exception("Todo not found");
        }
        await _todoRepository.DeleteTodoAsync(existingTodo);
    }
}
