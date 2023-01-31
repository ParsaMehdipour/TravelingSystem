using Factor.Application.Factors.Commands.DeleteFactor;
using Factor.Application.Factors.Queries.GetFactors;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelingSystem.Controllers.Base;

namespace TravelingSystem.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class FactorsController : BaseApiController
{
    public FactorsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<Result<IEnumerable<GetFactorsDto>>> Get(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetFactorsQuery(), cancellationToken);

        if (result.IsFailed)
            return Result.Fail(result.Errors);

        return result;
    }

    [HttpPut]
    public async Task<Result> Delete(DeleteFactorCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);

        if (result.IsFailed)
            return Result.Fail(result.Errors);

        return result;
    }
}
