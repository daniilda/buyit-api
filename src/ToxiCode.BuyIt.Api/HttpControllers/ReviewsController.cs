using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ToxiCode.BuyIt.Api.HttpControllers;

[ApiController]
[Route("v1/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReviewsController(IMediator mediator) 
        => _mediator = mediator;
}
