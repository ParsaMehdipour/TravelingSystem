using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Driver.InfrastructureEfCore.Persistence.Configurations;

public class DriverConfiguration : IEntityTypeConfiguration<Domain.Models.Driver>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Driver> builder)
    {
        builder.Property(_ => _.FirstName).IsRequired().HasMaxLength(50);

        builder.Property(_ => _.LastName).IsRequired().HasMaxLength(50);

        builder.Property(_ => _.NationalCode).IsRequired().HasMaxLength(50);

        builder.Property(_ => _.PhoneNumber).IsRequired().HasMaxLength(50);

        builder.Property(_ => _.CarBrand).IsRequired().HasMaxLength(50);

        builder.Property(_ => _.CarModel).IsRequired().HasMaxLength(50);

        builder.Property(_ => _.PlateNumber).IsRequired().HasMaxLength(50);

        builder.HasQueryFilter(entity => entity.IsDeleted == false);
    }
}
