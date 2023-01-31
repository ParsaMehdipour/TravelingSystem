using Driver.Domain.Models;
using Driver.Domain.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SH.InfrastructureEfCore.Extensions;

namespace Driver.InfrastructureEfCore.Persistence.SeedData;

public static class DriverSeedData
{
    public static async Task HandleDriverData(this IApplicationBuilder builder)
    {
        var scope = builder.ApplicationServices.CreateAsyncScope();
        var services = scope.ServiceProvider;

        var driverContext = services.GetService<DriverDbContext>();
        await driverContext.Database.MigrateAsync();
        await driverContext.Database.EnsureCreatedAsync();

        var driverRepository = services.GetRequiredService<IDriverRepository>();

        if (await driverRepository.IsExistsAsync(CancellationToken.None) is false)
        {
            var factory = services.GetRequiredService<DriverFactory>();

            List<Domain.Models.Driver> drivers = new()
            {
                factory.Create("امیر", "آقایی", "4980315433", "09112114447896","پژو","پارس","ایران 82"),
                factory.Create("حسین", "یزدی", "4980378434", "09122502549","رنو","تندر 90","ایران 72")
            };

            await driverRepository.AddRangeAsync(drivers, CancellationToken.None);
            await driverRepository.SaveAsync(CancellationToken.None);

            services.SeedLogger("Drivers Data Seeded!");
        }
    }
}
