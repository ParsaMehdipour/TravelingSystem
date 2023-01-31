using FluentResults;
using MediatR;
using Traveler.Application.Travelers.Commands.EditTraveler;
using Traveler.Domain.Repositories;

namespace Traveler.Application.Travelers.Queries.GetTraveler;

public class GetTravelerQueryHandler : IRequestHandler<GetTravelerQuery, Result<EditTravelerCommand>>
{
    protected ITravelerRepository _travelerRepository { get; }

    public GetTravelerQueryHandler(ITravelerRepository travelerRepository)
    {
        _travelerRepository = travelerRepository;
    }

    public async Task<Result<EditTravelerCommand>> Handle(GetTravelerQuery request, CancellationToken cancellationToken)
    {
        Domain.Models.Traveler traveler = await _travelerRepository.GetByIdAsync(cancellationToken, request.Id);

        ArgumentNullException.ThrowIfNull(traveler, nameof(traveler));

        return Result.Ok(request.ToCommand(traveler));
    }
}
