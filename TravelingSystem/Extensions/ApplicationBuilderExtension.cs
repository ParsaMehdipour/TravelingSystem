using Driver.InfrastructureEfCore.Persistence.SeedData;
using Traveler.infrastructureEfCore.Persistence.SeedData;

namespace TravelingSystem.Extensions;

public static class ApplicationBuilderExtension
{
    public static async Task InitializeSeedData(this IApplicationBuilder app)
    {
        await app.HandleTravelerData();
        await app.HandleDriverData();
    }
}
