using Driver.Application;
using Driver.Domain.Repositories;
using Driver.InfrastructureEfCore.Persistence;
using Driver.InfrastructureEfCore.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Driver.InfrastructureEfCore;

public static class DependencyInjection
{
    public static void AddDriverModule(this IServiceCollection services, string connectionString)
    {
        services.SetupInfrastructure(connectionString);

        services.SetupApplication();
    }

    public static void SetupInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DriverDbContext>(_ =>
        {
            _.UseSqlServer(connectionString);
        });

        services.AddScoped<IDriverRepository, DriverRepository>();
    }
}
