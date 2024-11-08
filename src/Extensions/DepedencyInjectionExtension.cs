using TodoListApi.Models;
using TodoListApi.Repositories;
using TodoListApi.Services;
using TodoListApi.Utils;

namespace TodoListApi.Extensions;

public static class DependencyInjectionExtension
{
  public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
  {
    services.AddScoped<ITodoRepository, TodoRepository>();
    services.AddScoped<ITodoService, TodoService>();
    services.AddScoped<IAuthRepository, AuthRepository>();
    services.AddScoped<IAuthService, AuthService>();
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<ISecurity, Security>();

    return services;
  }
}

