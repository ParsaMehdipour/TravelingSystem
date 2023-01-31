using FluentValidation;
using Journey.Domain.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Journey.Application;

public static class DependencyInjection
{
    public static void SetupApplication(this IServiceCollection services)
    {
        services.AddScoped<JourneyFactory>();

        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
