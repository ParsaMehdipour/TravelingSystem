using FluentResults;
using Journey.Application.journeys.Commands.ChangeJourneyStatus;
using Journey.Application.journeys.Commands.CreateJourney;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelingSystem.Controllers.Base;

namespace TravelingSystem.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class JourneysController : BaseApiController
{
    public JourneysController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<Result<long>> Create(CreateJourneyCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);

        if (result.IsFailed)
            return Result.Fail(result.Errors);

        return result;
    }

    [HttpPut]
    public async Task<Result> ChangeJourneyStatus(ChangeJourneyStatusCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);

        if (result.IsFailed)
            return Result.Fail(result.Errors);

        return result;
    }
}
