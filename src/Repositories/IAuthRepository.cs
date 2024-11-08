using TodoListApi.Models;

namespace TodoListApi.Repositories;

public interface IAuthRepository
{
  Task RegisterAsync(User User);
}