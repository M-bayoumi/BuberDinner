using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Infrastructure.Common.Implementation.Authentication;
using BuberDinner.Infrastructure.Common.Implementation.Services;
using Microsoft.Extensions.DependencyInjection;
namespace BuberDinner.Infrastructure;

public static class DependencycInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}
