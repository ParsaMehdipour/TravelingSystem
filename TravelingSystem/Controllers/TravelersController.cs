using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Traveler.Application.Travelers.Commands.CreateTraveler;
using Traveler.Application.Travelers.Commands.DeleteTraveler;
using Traveler.Application.Travelers.Commands.EditTraveler;
using Traveler.Application.Travelers.Queries.GetTraveler;
using Traveler.Application.Travelers.Queries.GetTravelers;
using TravelingSystem.Controllers.Base;

namespace TravelingSystem.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class TravelersController : BaseApiController
{
    public TravelersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<Result<IEnumerable<GetTravelersDto>>> Get(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetTravelersQuery(), cancellationToken);

        if (result.IsFailed)
            return Result.Fail(result.Errors);

        return result;
    }

    [HttpGet("{id}")]
    public async Task<Result<EditTravelerCommand>> GetById(long id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetTravelerQuery(id), cancellationToken);

        if (result.IsFailed)
            return Result.Fail(result.Errors);

        return result;
    }

    [HttpPost]
    public async Task<Result<long>> Create(CreateTravelerCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);

        if (result.IsFailed)
            return Result.Fail(result.Errors);

        return result;
    }

    [HttpPut]
    public async Task<Result> Delete(DeleteTravelerCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);

        if (result.IsFailed)
            return Result.Fail(result.Errors);

        return result;
    }

    [HttpPut]
    public async Task<Result> Edit(EditTravelerCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);

        if (result.IsFailed)
            return Result.Fail(result.Errors);

        return result;
    }
}
