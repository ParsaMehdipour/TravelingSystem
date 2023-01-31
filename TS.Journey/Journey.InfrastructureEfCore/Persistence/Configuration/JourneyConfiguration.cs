using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Journey.InfrastructureEfCore.Persistence.Configuration;

public class JourneyConfiguration : IEntityTypeConfiguration<Domain.Models.Journey>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Journey> builder)
    {
        builder.Property(_ => _.Date).IsRequired().HasMaxLength(50);

        builder.Property(_ => _.Start).IsRequired().HasMaxLength(50);

        builder.Property(_ => _.Destination).IsRequired().HasMaxLength(50);

        builder.Property(_ => _.TravelerId).IsRequired();

        builder.Property(_ => _.DriverId).IsRequired();

        builder.Property(_ => _.Code).IsRequired();

        builder.HasQueryFilter(entity => entity.IsDeleted == false);
    }
}
