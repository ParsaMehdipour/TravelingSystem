using Factor.Domain.Models;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Factor.Application;

public static class DependencyInjection
{
    public static void SetupApplication(this IServiceCollection services)
    {
        services.AddScoped<FactorFactory>();

        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
