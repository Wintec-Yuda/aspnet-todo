using TodoListApi.Data;
using TodoListApi.Repositories;

namespace TodoListApi.Models;

public class AuthRepository : IAuthRepository
{
  private readonly AppDbContext _context;

  public AuthRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task RegisterAsync(User user)
  {
    var newUser = await _context.Users.AddAsync(user);
    await _context.SaveChangesAsync();
  }
}