using Microsoft.EntityFrameworkCore;
using TodoListApi.Data;
using TodoListApi.DTO;
using TodoListApi.Models;

namespace TodoListApi.Repositories;
public class TodoRepository : ITodoRepository
{
  private readonly AppDbContext _context;

  public TodoRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<Todo>> GetAllTodos()
  {
    return await _context.Todos.ToListAsync();
  }
  public async Task<Todo?> GetTodoById(Guid id)
  {
    return await _context.Todos.FindAsync(id);
  }
  public async Task<Todo?> CreateTodo(Todo todo) 
  {
    var newTodo = await _context.Todos.AddAsync(todo);
    await _context.SaveChangesAsync();
    return newTodo.Entity;
  }
  public async Task UpdateTodo(Todo todo)
  {
    _context.Todos.Update(todo);
    await _context.SaveChangesAsync();
  }
  public async Task DeleteTodo(Todo todo)
  {
    _context.Todos.Remove(todo);
    await _context.SaveChangesAsync();
  }
  public async Task<IEnumerable<TodoResponseDTO>> GetTodosByUserId(Guid userId)
  {
    return await _context.Todos
      .Where(t => t.UserId == userId)
      .Select(t => new TodoResponseDTO
      {
        Id = t.Id,
        Title = t.Title,
        Description = t.Description,
        IsCompleted = t.IsCompleted
      })
      .ToListAsync();
  }
}
