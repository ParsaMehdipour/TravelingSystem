using FluentResults;
using MediatR;
using Traveler.Domain.Repositories;

namespace Traveler.Application.Travelers.Commands.DeleteTraveler;

public class DeleteTravelerCommandHandler : IRequestHandler<DeleteTravelerCommand, Result>
{
    protected ITravelerRepository _travelerRepository { get; }

    public DeleteTravelerCommandHandler(ITravelerRepository travelerRepository)
    {
        _travelerRepository = travelerRepository;
    }

    public async Task<Result> Handle(DeleteTravelerCommand request, CancellationToken cancellationToken)
    {
        Domain.Models.Traveler traveler = await _travelerRepository.GetWithoutQueryFilterAsync(_ => _.Id == request.Id, cancellationToken);

        ArgumentNullException.ThrowIfNull(traveler, nameof(traveler));

        if (request.IsRestore)
            traveler.RestoreItem();
        else
            traveler.DeleteItem();

        _travelerRepository.Update(traveler);
        await _travelerRepository.SaveAsync(cancellationToken);

        return Result.Ok();
    }
}
