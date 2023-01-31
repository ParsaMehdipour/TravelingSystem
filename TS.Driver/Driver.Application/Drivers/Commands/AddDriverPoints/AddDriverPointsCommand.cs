using FluentResults;
using MediatR;

namespace Driver.Application.Drivers.Commands.AddDriverPoints;

public record AddDriverPointsCommand(long Id, int Point) : IRequest<Result>;

