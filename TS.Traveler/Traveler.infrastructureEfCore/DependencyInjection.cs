using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Traveler.Application;
using Traveler.Domain.Repositories;
using Traveler.infrastructureEfCore.Persistence;
using Traveler.infrastructureEfCore.Persistence.Repositories;

namespace Traveler.infrastructureEfCore;
public static class DependencyInjection
{
    public static void AddTravelerModule(this IServiceCollection services, string connectionString)
    {
        services.SetupInfrastructure(connectionString);

        services.SetupApplication();
    }

    public static void SetupInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<TravelerDbContext>(_ =>
        {
            _.UseSqlServer(connectionString);
        });

        services.AddScoped<ITravelerRepository, TravelerRepository>();
    }
}
