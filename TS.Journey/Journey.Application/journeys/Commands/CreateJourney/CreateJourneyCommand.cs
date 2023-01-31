using FluentResults;
using Journey.Domain.Enums;
using MediatR;

namespace Journey.Application.journeys.Commands.CreateJourney;

public record CreateJourneyCommand(string Date, string Start, string Destination, string Code, string DiscountCode, JourneyStatus Status, long TravelerId, long DriverId) : IRequest<Result<long>>;
