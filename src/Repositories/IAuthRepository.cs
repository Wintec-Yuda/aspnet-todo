using TodoListApi.Models;

namespace TodoListApi.Repositories;

public interface IAuthRepository
{
  Task Register(User User);
}