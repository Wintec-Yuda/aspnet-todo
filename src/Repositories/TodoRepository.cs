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

  public async Task<IEnumerable<Todo>> GetAllTodosAsync()
  {
    return await _context.Todos.ToListAsync();
  }
  public async Task<Todo?> GetTodoByIdAsync(Guid id)
  {
    return await _context.Todos.FindAsync(id);
  }
  public async Task<Todo?> CreateTodoAsync(TodoCreateDTO todoDto) 
  {
    var todo = new Todo
    {
      Title = todoDto.Title,
      Description = todoDto.Description,
      IsCompleted = todoDto.IsCompleted,
    };
    var newTodo = await _context.Todos.AddAsync(todo);
    await _context.SaveChangesAsync();
    return newTodo.Entity;
  }
  public async Task UpdateTodoAsync(Todo todo)
  {
    _context.Todos.Update(todo);
    await _context.SaveChangesAsync();
  }
  public async Task DeleteTodoAsync(Todo todo)
  {
    _context.Todos.Remove(todo);
    await _context.SaveChangesAsync();
  }
}
