using TodoListApi.DTO;
using TodoListApi.Models;
using TodoListApi.Repositories;

namespace TodoListApi.Services;
public class TodoService : ITodoService
{
    private readonly ITodoRepository _repository;

    public TodoService(ITodoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Todo>> GetAllTodosAsync()
    {
        return await _repository.GetAllTodosAsync();
    }
    public async Task<Todo?> GetTodoByIdAsync(Guid id)
    {
        return await _repository.GetTodoByIdAsync(id);
    }
    public async Task<Todo?> CreateTodoAsync(TodoRequestDTO todoDto)
    {
        return await _repository.CreateTodoAsync(todoDto);
    }
    public async Task UpdateTodoAsync(Guid id, TodoRequestDTO todoDto)
    {
        var todo = await _repository.GetTodoByIdAsync(id);
        if (todo == null)
        {
            throw new Exception("Todo not found");
        }

        todo.Title = todoDto.Title!;
        todo.Description = todoDto.Description!;
        todo.IsCompleted = todoDto.IsCompleted;
        await _repository.UpdateTodoAsync(todo);
    }
    public async Task DeleteTodoAsync(Guid id)
    {
        var existingTodo = await _repository.GetTodoByIdAsync(id);
        if (existingTodo == null)
        {
            throw new Exception("Todo not found");
        }
        await _repository.DeleteTodoAsync(existingTodo);
    }
}
