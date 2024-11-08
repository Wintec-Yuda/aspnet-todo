using TodoListApi.Models;

namespace TodoListApi.Repositories;

public interface IUserRepository
{
  Task<User?> getUserByEmail(string email);
}