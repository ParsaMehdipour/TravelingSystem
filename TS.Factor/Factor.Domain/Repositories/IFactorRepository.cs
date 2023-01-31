using SH.Domain.Interfaces;

namespace Factor.Domain.Repositories;

public interface IFactorRepository : IBaseRepository<Models.Factor>
{
    Task<bool> TravelIdExists(long id, long travelId, bool isForModify, CancellationToken cancellationToken);
}
