using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Traveler.infrastructureEfCore.Persistence.Configurations;

public class TravelerConfiguration : IEntityTypeConfiguration<Domain.Models.Traveler>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Traveler> builder)
    {
        builder.Property(_ => _.FirstName).IsRequired().HasMaxLength(50);

        builder.Property(_ => _.LastName).IsRequired().HasMaxLength(50);

        builder.Property(_ => _.NationalCode).IsRequired().HasMaxLength(50);

        builder.Property(_ => _.PhoneNumber).IsRequired().HasMaxLength(50);

        builder.HasQueryFilter(entity => entity.IsDeleted == false);
    }
}
