using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Traveler.Domain.Models;

namespace Traveler.Application;

public static class DependencyInjection
{
    public static void SetupApplication(this IServiceCollection services)
    {
        services.AddScoped<TravelerFactory>();

        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
