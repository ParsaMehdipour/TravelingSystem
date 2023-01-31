using FluentResults;
using MediatR;

namespace Factor.Application.Factors.Queries.GetFactors;

public record GetFactorsQuery : IRequest<Result<IEnumerable<GetFactorsDto>>>;

public record GetFactorsDto(long Id, string TravelCode, string Price, int DiscountRate, long TravelerId, long JourneyId, long DriverId, string FinalPrice, string CreatedDate);
