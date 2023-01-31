using FluentResults;
using MediatR;
using Traveler.Domain.Models;
using Traveler.Domain.Repositories;

namespace Traveler.Application.Travelers.Commands.CreateTraveler;

public class CreateTravelerCommandHandler : IRequestHandler<CreateTravelerCommand, Result<long>>
{
    protected ITravelerRepository _travelerRepository { get; }
    protected TravelerFactory _travelerFactory { get; }

    public CreateTravelerCommandHandler(ITravelerRepository travelerRepository, TravelerFactory travelerFactory)
    {
        _travelerRepository = travelerRepository;
        _travelerFactory = travelerFactory;
    }

    public async Task<Result<long>> Handle(CreateTravelerCommand request, CancellationToken cancellationToken)
    {
        Domain.Models.Traveler traveler = _travelerFactory.Create(request.FirstName, request.LastName, request.NationalCode, request.PhoneNumber);

        await _travelerRepository.AddAsync(traveler, cancellationToken);
        await _travelerRepository.SaveAsync(cancellationToken);

        return Result.Ok(traveler.Id);
    }
}
