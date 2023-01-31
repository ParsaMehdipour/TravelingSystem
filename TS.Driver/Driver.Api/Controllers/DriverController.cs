using Driver.Api.Controllers.Base;
using Driver.Application.Drivers.Commands.AddDriverPoints;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Driver.Api.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class DriverController : BaseApiController
{
    public DriverController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// Add Points to the Driver after the Journey is Finished
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<Result> AddDriverPoints(AddDriverPointsCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);

        if (result.IsFailed)
            return Result.Fail(result.Errors);

        return result;
    }
}
