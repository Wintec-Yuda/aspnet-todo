using TodoListApi.DTO;
using TodoListApi.Models;

namespace TodoListApi.Services;

public interface IAuthService
{
  Task Register(UserRegisterDTO registerDto);
  Task<string?> Login(UserLoginDTO loginDto);
}