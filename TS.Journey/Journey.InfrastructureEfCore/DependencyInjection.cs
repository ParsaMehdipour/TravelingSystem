using Journey.Application;
using Journey.Domain.Repositories;
using Journey.InfrastructureEfCore.Persistence;
using Journey.InfrastructureEfCore.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Journey.InfrastructureEfCore;

public static class DependencyInjection
{
    public static void AddJourneyModule(this IServiceCollection services, string connectionString)
    {
        services.SetupInfrastructure(connectionString);

        services.SetupApplication();
    }

    public static void SetupInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<JourneyDbContext>(_ =>
        {
            _.UseSqlServer(connectionString);
        });

        services.AddScoped<IJourneyRepository, JourneyRepository>();
    }
}
