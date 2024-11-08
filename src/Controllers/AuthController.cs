using Microsoft.AspNetCore.Mvc;
using TodoListApi.DTO;
using TodoListApi.Services;

namespace TodoListApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
  private readonly IAuthService _authService;

  public AuthController(IAuthService authService)
  {
    _authService = authService;
  }

  [HttpPost("register")]
  public async Task<IActionResult> RegisterAsync(UserRegisterDTO registerDto)
  {
    await _authService.RegisterAsync(registerDto);
    return Ok(new
    {
      status = "success",
      message = "User registered successfully",
    });
  }

  [HttpPost("login")]
  public async Task<IActionResult> LoginAsync(UserLoginDTO loginDto)
  {
    var token = await _authService.LoginAsync(loginDto);
    if (token == null)
    {
      return Unauthorized(new {
        status = "error",
        message = "Invalid username or password"
      });
    }  
    return Ok(new {
      status = "success",
      message = "Login Successfully",
      token
    });
  }
}