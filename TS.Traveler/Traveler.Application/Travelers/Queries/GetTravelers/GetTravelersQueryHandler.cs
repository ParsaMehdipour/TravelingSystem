using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SH.InfrastructureEfCore.Extensions;
using Traveler.Domain.Repositories;

namespace Traveler.Application.Travelers.Queries.GetTravelers;
public class GetTravelersQueryHandler : IRequestHandler<GetTravelersQuery, Result<IEnumerable<GetTravelersDto>>>
{
    protected ITravelerRepository _travelerRepository { get; }

    public GetTravelersQueryHandler(ITravelerRepository travelerRepository)
    {
        _travelerRepository = travelerRepository;
    }

    public async Task<Result<IEnumerable<GetTravelersDto>>> Handle(GetTravelersQuery request, CancellationToken cancellationToken)
    {
        var travelers = _travelerRepository.Get();

        var result = await travelers.Select(_ => new GetTravelersDto(
            _.Id,
            _.FirstName,
            _.LastName,
            _.NationalCode,
            _.PhoneNumber,
            _.CreatedDate.ToPersian()
            )).ToListAsync(cancellationToken);

        return Result.Ok(result.AsEnumerable()); //AsReadOnly() doesn't work
    }
}
