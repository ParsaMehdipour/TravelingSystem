using Factor.Api.Controllers.Base;
using Factor.Application.Factors.Commands.CreateFactor;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Factor.Api.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class FactorsController : BaseApiController
{
    public FactorsController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// Create a Factor for journey service and return factorId with distance
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<CreateFactorDto>> Create(CreateFactorCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);

        return result.Value;
    }

}
