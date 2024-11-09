using TodoListApi.DTO;
using TodoListApi.Models;
using TodoListApi.Repositories;
using TodoListApi.Utils;

namespace TodoListApi.Services;

public class AuthService : IAuthService
{
  private readonly IAuthRepository _authRepository;
  private readonly IUserRepository _userRepository;
  private readonly ISecurity _security;

  public AuthService(IAuthRepository authRepository, IUserRepository userRepository, ISecurity security)
  {
    _authRepository = authRepository;
    _userRepository = userRepository;
    _security = security;
  }

  public async Task Register(UserRegisterDTO registerDto)
  {
    var user = new User
    {
      Name = registerDto.Name!,
      Email = registerDto.Email!,
      Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password)
    };
    await _authRepository.Register(user);
  }

  public async Task<string?> Login(UserLoginDTO loginDto)
  {
    var user = await _userRepository.GetUserByEmail(loginDto.Email!);
    if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
    {
      return null!;
    }
    return _security.GenerateJwtToken(user);
  }


}