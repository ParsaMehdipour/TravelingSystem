using Journey.Domain.Repositories;
using SH.InfrastructureEfCore.EfCore.Repositories;

namespace Journey.InfrastructureEfCore.Persistence.Repositories;

public class JourneyRepository : EfRepository<Domain.Models.Journey>, IJourneyRepository
{
    public JourneyRepository(JourneyDbContext context) : base(context)
    {
    }
}
