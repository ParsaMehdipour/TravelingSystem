using Factor.Application;
using Factor.Domain.Repositories;
using Factor.InfrastructureEfCore.Persistence;
using Factor.InfrastructureEfCore.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Factor.InfrastructureEfCore;

public static class DependencyInjection
{
    public static void AddFactorModule(this IServiceCollection services, string connectionString)
    {
        services.SetupInfrastructure(connectionString);

        services.SetupApplication();
    }

    public static void SetupInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<FactorDbContext>(_ =>
        {
            _.UseSqlServer(connectionString);
        });

        services.AddScoped<IFactorRepository, FactorRepository>();
    }
}
