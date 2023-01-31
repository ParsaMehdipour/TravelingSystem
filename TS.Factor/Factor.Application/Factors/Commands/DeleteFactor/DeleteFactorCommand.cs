using FluentResults;
using MediatR;

namespace Factor.Application.Factors.Commands.DeleteFactor;

public record DeleteFactorCommand(long Id, bool IsRestore) : IRequest<Result>;
