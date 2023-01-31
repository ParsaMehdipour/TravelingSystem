using FluentResults;
using MediatR;
using Traveler.Domain.Repositories;

namespace Traveler.Application.Travelers.Commands.EditTraveler;

public class EditTravelerCommandHandler : IRequestHandler<EditTravelerCommand, Result>
{
    protected ITravelerRepository _travelerRepository { get; }

    public EditTravelerCommandHandler(ITravelerRepository travelerRepository)
    {
        _travelerRepository = travelerRepository;
    }

    public async Task<Result> Handle(EditTravelerCommand request, CancellationToken cancellationToken)
    {
        Domain.Models.Traveler traveler = await _travelerRepository.GetByIdAsync(cancellationToken, request.Id);

        ArgumentNullException.ThrowIfNull(traveler, nameof(traveler));

        traveler.SetFirstName(request.FirstName);
        traveler.SetLastName(request.LastName);
        traveler.SetNationalCode(request.NationalCode);
        traveler.SetPhoneNumber(request.PhoneNumber);

        _travelerRepository.Update(traveler);
        await _travelerRepository.SaveAsync(cancellationToken);

        return Result.Ok();
    }
}
