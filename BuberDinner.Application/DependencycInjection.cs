using BuberDinner.Application.Services.AuthenticationServices;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application;

public static class DependencycInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}
