﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TravelingSystem.Controllers.Base;
[Route("api/[controller]")]
[ApiController]
public class BaseApiController : ControllerBase
{
    protected IMediator _mediator { get; }

    public BaseApiController(IMediator mediator)
    {
        _mediator = mediator;
    }

}
