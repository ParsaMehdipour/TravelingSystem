using Driver.Domain.Models;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Driver.Application;
public static class DependencyInjection
{
    public static void SetupApplication(this IServiceCollection services)
    {
        services.AddScoped<DriverFactory>();

        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
