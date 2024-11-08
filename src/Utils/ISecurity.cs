using TodoListApi.Models;

namespace TodoListApi.Utils;

public interface ISecurity
{
  string GenerateJwtToken(User user);
}