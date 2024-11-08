using TodoListApi.DTO;
using TodoListApi.Models;

namespace TodoListApi.Services;

public interface IAuthService
{
  Task RegisterAsync(UserRegisterDTO registerDto);
  Task<string?> LoginAsync(UserLoginDTO loginDto);
}