using FluentResults;
using Journey.Domain.Enums;
using MediatR;

namespace Journey.Application.journeys.Commands.ChangeJourneyStatus;

public record ChangeJourneyStatusCommand(long Id, JourneyStatus Status) : IRequest<Result>;

