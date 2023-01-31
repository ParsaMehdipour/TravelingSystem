using SH.Domain.Interfaces;

namespace Traveler.Domain.Repositories;

public interface ITravelerRepository : IBaseRepository<Models.Traveler>
{
    Task<bool> NationalCodeExists(long id, string nationalCode, bool isForModify, CancellationToken cancellationToken);
    Task<bool> PhoneNumberExists(long id, string phoneNumber, bool isForModify, CancellationToken cancellationToken);
}
