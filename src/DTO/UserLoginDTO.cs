using System.ComponentModel.DataAnnotations;

namespace TodoListApi.DTO;

public class UserLoginDTO
{
  [Required]
  public string? Email { get; set; }
  [Required]
  public string? Password { get; set; }
}