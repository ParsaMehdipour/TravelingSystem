using FluentResults;
using MediatR;
using Traveler.Application.Travelers.Commands.EditTraveler;

namespace Traveler.Application.Travelers.Queries.GetTraveler;

public record GetTravelerQuery(long Id) : IRequest<Result<EditTravelerCommand>>
{
    internal EditTravelerCommand ToCommand(Domain.Models.Traveler Travel) =>
        new(Travel.Id,
            Travel.FirstName,
            Travel.LastName,
            Travel.NationalCode,
            Travel.PhoneNumber);
}
