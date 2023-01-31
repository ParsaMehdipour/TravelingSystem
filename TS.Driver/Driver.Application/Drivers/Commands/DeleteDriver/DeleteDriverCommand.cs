using FluentResults;
using MediatR;

namespace Driver.Application.Drivers.Commands.DeleteDriver;

public record DeleteDriverCommand(long Id, bool IsRestore) : IRequest<Result>;
