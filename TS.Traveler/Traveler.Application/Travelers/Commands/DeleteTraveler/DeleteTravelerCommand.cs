using FluentResults;
using MediatR;

namespace Traveler.Application.Travelers.Commands.DeleteTraveler;

public record DeleteTravelerCommand(long Id, bool IsRestore) : IRequest<Result>;
