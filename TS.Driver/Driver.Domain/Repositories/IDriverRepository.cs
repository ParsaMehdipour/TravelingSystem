using SH.Domain.Interfaces;

namespace Driver.Domain.Repositories;

public interface IDriverRepository : IBaseRepository<Models.Driver>
{
    Task<bool> NationalCodeExists(long id, string nationalCode, bool isForModify, CancellationToken cancellationToken);
    Task<bool> PhoneNumberExists(long id, string phoneNumber, bool isForModify, CancellationToken cancellationToken);
    Task<bool> PlateNumberExists(long id, string plateNumber, bool isForModify, CancellationToken cancellationToken);
}
