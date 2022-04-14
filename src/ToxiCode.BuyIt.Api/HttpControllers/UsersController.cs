using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ToxiCode.BuyIt.Api.HttpControllers;

public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator) 
        => _mediator = mediator;
}