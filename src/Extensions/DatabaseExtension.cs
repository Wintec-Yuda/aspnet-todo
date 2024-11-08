using Microsoft.EntityFrameworkCore;
using TodoListApi.Data;

namespace TodoListApi.Extensions;

public static class DatabaseExtension
{
  public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

    return services;
  }
}

