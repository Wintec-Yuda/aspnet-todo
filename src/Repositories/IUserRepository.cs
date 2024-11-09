using TodoListApi.Models;

namespace TodoListApi.Repositories;

public interface IUserRepository
{
  Task<User?> GetUserByEmail(string email);
  Task<User?> GetUserById(Guid id);
}