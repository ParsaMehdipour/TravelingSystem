using Factor.Domain.Repositories;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SH.InfrastructureEfCore.Extensions;

namespace Factor.Application.Factors.Queries.GetFactors;
public class GetFactorsQueryHandler : IRequestHandler<GetFactorsQuery, Result<IEnumerable<GetFactorsDto>>>
{
    protected IFactorRepository _factorRepository { get; }

    public GetFactorsQueryHandler(IFactorRepository factorRepository)
    {
        _factorRepository = factorRepository;
    }

    public async Task<Result<IEnumerable<GetFactorsDto>>> Handle(GetFactorsQuery request, CancellationToken cancellationToken)
    {
        var travelers = _factorRepository.Get();

        var result = await travelers.Select(_ => new GetFactorsDto(
            _.Id,
            _.TravelCode,
            _.Price.ToString("n0"),
            _.DiscountRate,
            _.TravelerId,
            _.JourneyId,
            _.DriverId,
            _.FinalPrice.ToString("n0"),
            _.CreatedDate.ToPersian()
            )).ToListAsync(cancellationToken);

        return Result.Ok(result.AsEnumerable()); //AsReadOnly() doesn't work
    }
}
