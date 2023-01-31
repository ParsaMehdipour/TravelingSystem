using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SH.InfrastructureEfCore.Extensions;
using Traveler.Domain.Models;
using Traveler.Domain.Repositories;

namespace Traveler.infrastructureEfCore.Persistence.SeedData;

public static class TravelerSeedData
{
    public static async Task HandleTravelerData(this IApplicationBuilder builder)
    {
        var scope = builder.ApplicationServices.CreateAsyncScope();
        var services = scope.ServiceProvider;

        var travelerContext = services.GetService<TravelerDbContext>();
        await travelerContext.Database.MigrateAsync();
        await travelerContext.Database.EnsureCreatedAsync();

        var travelerRepository = services.GetRequiredService<ITravelerRepository>();

        if (await travelerRepository.IsExistsAsync(CancellationToken.None) is false)
        {
            var factory = services.GetRequiredService<TravelerFactory>();

            List<Domain.Models.Traveler> travelers = new()
            {
                factory.Create("پارسا", "مهدی پور", "4980316433", "09122502978"),
                factory.Create("امیر", "عرفانی", "4980316434", "09122502979")
            };

            await travelerRepository.AddRangeAsync(travelers, CancellationToken.None);
            await travelerRepository.SaveAsync(CancellationToken.None);

            services.SeedLogger("Travelers Data Seeded!");
        }
    }
}
