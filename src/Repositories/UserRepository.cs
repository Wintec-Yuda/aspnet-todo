using Microsoft.EntityFrameworkCore;
using TodoListApi.Data;
using TodoListApi.Models;

namespace TodoListApi.Repositories;

class UserRepository : IUserRepository
{
  private readonly AppDbContext _context;

  public UserRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<User?> getUserByEmail(string email)
  {
    return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
  }
}