using Driver.Application.Drivers.Commands.AddDriverPoints;
using Driver.Application.Drivers.Commands.ChangeDriverStatus;
using Driver.Application.Drivers.Commands.CreateDriver;
using Driver.Application.Drivers.Commands.DeleteDriver;
using Driver.Application.Drivers.Commands.EditDriver;
using Driver.Application.Drivers.Queries.GetDriver;
using Driver.Application.Drivers.Queries.GetDrivers;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelingSystem.Controllers.Base;

namespace TravelingSystem.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class DriversController : BaseApiController
{
    public DriversController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<Result<IEnumerable<GetDriversDto>>> Get(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetDriversQuery(), cancellationToken);

        if (result.IsFailed)
            return Result.Fail(result.Errors);

        return result;
    }

    [HttpGet("{id}")]
    public async Task<Result<EditDriverCommand>> GetById(long id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetDriverQuery(id), cancellationToken);

        if (result.IsFailed)
            return Result.Fail(result.Errors);

        return result;
    }

    [HttpPost]
    public async Task<Result<long>> Create(CreateDriverCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);

        if (result.IsFailed)
            return Result.Fail(result.Errors);

        return result;
    }

    [HttpPut]
    public async Task<Result> Edit(EditDriverCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);

        if (result.IsFailed)
            return Result.Fail(result.Errors);

        return result;
    }

    [HttpPut]
    public async Task<Result> Delete(DeleteDriverCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);

        if (result.IsFailed)
            return Result.Fail(result.Errors);

        return result;
    }



    [HttpPut]
    public async Task<Result> ChangeStatus(ChangeDriverStatusCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);

        if (result.IsFailed)
            return Result.Fail(result.Errors);

        return result;
    }

    [HttpPut]
    public async Task<Result> AddPoints(AddDriverPointsCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);

        if (result.IsFailed)
            return Result.Fail(result.Errors);

        return result;
    }
}
