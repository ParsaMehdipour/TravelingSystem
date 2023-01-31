using Driver.Domain.Repositories;
using SH.InfrastructureEfCore.EfCore.Repositories;

namespace Driver.InfrastructureEfCore.Persistence.Repositories;

public class DriverRepository : EfRepository<Domain.Models.Driver>, IDriverRepository
{
    public DriverRepository(DriverDbContext context) : base(context)
    {
    }

    public async Task<bool> NationalCodeExists(long id, string nationalCode, bool isForModify, CancellationToken cancellationToken)
    {
        bool isExists;

        if (isForModify is false)
            isExists = await this.IsExistsAsync(_ => _.NationalCode.Equals(nationalCode), cancellationToken);
        else
            isExists = await this.IsExistsAsync(_ => !_.Id.Equals(id) && _.NationalCode.Equals(nationalCode), cancellationToken);

        return isExists;
    }

    public async Task<bool> PhoneNumberExists(long id, string phoneNumber, bool isForModify, CancellationToken cancellationToken)
    {
        bool isExists;

        if (isForModify is false)
            isExists = await this.IsExistsAsync(_ => _.PhoneNumber.Equals(phoneNumber), cancellationToken);
        else
            isExists = await this.IsExistsAsync(_ => !_.Id.Equals(id) && _.PhoneNumber.Equals(phoneNumber), cancellationToken);

        return isExists;
    }

    public async Task<bool> PlateNumberExists(long id, string plateNumber, bool isForModify, CancellationToken cancellationToken)
    {
        bool isExists;

        if (isForModify is false)
            isExists = await this.IsExistsAsync(_ => _.PhoneNumber.Equals(plateNumber), cancellationToken);
        else
            isExists = await this.IsExistsAsync(_ => !_.Id.Equals(id) && _.PhoneNumber.Equals(plateNumber), cancellationToken);

        return isExists;
    }
}
