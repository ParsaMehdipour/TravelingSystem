using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SH.Application;
using SH.Domain.Interfaces;
using SH.InfrastructureEfCore.EfCore;
using SH.InfrastructureEfCore.EfCore.Repositories;
using SH.InfrastructureEfCore.Policies;
using SH.InfrastructureEfCore.Services;

namespace SH.InfrastructureEfCore;
public static class DependencyInjection
{
    public static void AddSharedKernel(this IServiceCollection services, string connectionString)
    {
        services.SetupInfrastructure(connectionString);

        services.SetupApplication();
    }

    internal static void SetupInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddScoped(typeof(IBaseRepository<>), typeof(EfRepository<>));
        services.AddScoped(typeof(IQueryRepository<>), typeof(EfQueryRepository<>));

        services.AddDbContext<ApplicationDbContext>(_ =>
        {
            _.UseSqlServer(connectionString);
        });

        services.AddHttpClient();

        services.AddHttpClient<HttpClientService>("BaseHttpClientService").AddPolicyHandler(request => request.Method != HttpMethod.Get ?
            new ClientPolicy().ImmediateHttpRetry :
            new ClientPolicy().LinearHttpRetry);
    }
}
