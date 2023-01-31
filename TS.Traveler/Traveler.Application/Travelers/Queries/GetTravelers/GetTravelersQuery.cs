using FluentResults;
using MediatR;

namespace Traveler.Application.Travelers.Queries.GetTravelers;

public record GetTravelersQuery : IRequest<Result<IEnumerable<GetTravelersDto>>>;

public record GetTravelersDto(long Id, string FirstName, string LastName, string NationalCode, string PhoneNumber, string CreatedDate);
