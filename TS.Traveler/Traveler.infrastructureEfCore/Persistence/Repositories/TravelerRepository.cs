using SH.InfrastructureEfCore.EfCore.Repositories;
using Traveler.Domain.Repositories;

namespace Traveler.infrastructureEfCore.Persistence.Repositories;

public class TravelerRepository : EfRepository<Domain.Models.Traveler>, ITravelerRepository
{
    public TravelerRepository(TravelerDbContext context) : base(context)
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
}
