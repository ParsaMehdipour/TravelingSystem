using Factor.Domain.Repositories;
using SH.InfrastructureEfCore.EfCore.Repositories;

namespace Factor.InfrastructureEfCore.Persistence.Repositories;

public class FactorRepository : EfRepository<Domain.Models.Factor>, IFactorRepository
{
    public FactorRepository(FactorDbContext context) : base(context)
    {
    }

    public Task<bool> TravelIdExists(long id, long travelId, bool isForModify, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
