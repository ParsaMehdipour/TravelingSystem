using FluentResults;
using MediatR;

namespace Traveler.Application.Travelers.Commands.EditTraveler;

public record EditTravelerCommand(long Id, string FirstName, string LastName, string NationalCode, string PhoneNumber) : IRequest<Result>;

