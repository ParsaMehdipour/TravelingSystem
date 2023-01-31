using FluentResults;
using MediatR;

namespace Traveler.Application.Travelers.Commands.CreateTraveler;

public record CreateTravelerCommand(string FirstName, string LastName, string NationalCode, string PhoneNumber) : IRequest<Result<long>>;

