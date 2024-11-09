using Microsoft.AspNetCore.Mvc;
using TodoListApi.DTO;
using TodoListApi.Services;
using TodoListApi.Utils;

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
  public async Task<IActionResult> Register(UserRegisterDTO registerDto)
  {
    await _authService.Register(registerDto);
    return Ok(new
    {
      status = "success",
      message = "User registered successfully",
    });
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login(UserLoginDTO loginDto)
  {
    var token = await _authService.Login(loginDto);
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

  [HttpGet("claims/{token}")]
  public IActionResult GetClaims(string token)
  {
    var claims = Security.GetClaimValue(token);
    return Ok(new
    {
      status = "success",
      message = "Claims retrieved successfully",
      data = claims
    });
  }
}