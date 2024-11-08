using System.ComponentModel.DataAnnotations;

namespace TodoListApi.DTO
{
  public class UserRegisterDTO
  {
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string? Name { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string? Password { get; set; }
  }
}