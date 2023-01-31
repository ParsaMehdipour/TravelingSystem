using FluentResults;
using MediatR;

namespace Factor.Application.Factors.Commands.CreateFactor;

public record CreateFactorCommand(long JourneyId, long TravelerId, long DriverId, string Start, string Destination, int DiscountRate) : IRequest<Result<CreateFactorDto>>;

public record CreateFactorDto(long FactorId, int Distance);