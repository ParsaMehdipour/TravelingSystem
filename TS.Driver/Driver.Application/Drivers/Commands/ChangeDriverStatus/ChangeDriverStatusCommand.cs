using FluentResults;
using MediatR;

namespace Driver.Application.Drivers.Commands.ChangeDriverStatus;

public record ChangeDriverStatusCommand(long Id, bool Status) : IRequest<Result>;
