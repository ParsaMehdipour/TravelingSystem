using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Factor.InfrastructureEfCore.Persistence.Configuration;

public class FactorConfiguration : IEntityTypeConfiguration<Domain.Models.Factor>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Factor> builder)
    {
        builder.Property(_ => _.TravelCode).IsRequired().HasMaxLength(50);

        builder.Property(_ => _.Price).IsRequired();

        builder.Property(_ => _.FinalPrice).IsRequired();

        builder.Property(_ => _.TravelerId).IsRequired();

        builder.Property(_ => _.DriverId).IsRequired();

        builder.Property(_ => _.JourneyId).IsRequired();

        builder.HasQueryFilter(entity => entity.IsDeleted == false);
    }
}
