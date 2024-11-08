using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TodoListApi.Models;

namespace TodoListApi.Utils;

public class Security : ISecurity
{
  private readonly IConfiguration _configuration;

  public Security(IConfiguration configuration)
  {
    _configuration = configuration;
  }
  public string GenerateJwtToken(User user)
  {
    var claims = new[]
    {
      new Claim(ClaimTypes.Name, user.Name),
      new Claim(ClaimTypes.Role, user.Role)
    };

    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken
    (
      _configuration["Jwt:Issuer"],
      _configuration["Jwt:Audience"],
      claims,
      expires: DateTime.Now.AddMinutes(30),
      signingCredentials: creds
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}