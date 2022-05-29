using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToxiCode.BuyIt.Api.Handlers.Facade.GetFrontPageAggregation.Dtos;
using ToxiCode.BuyIt.Api.Platform;

namespace ToxiCode.BuyIt.Api.HttpControllers;

[ApiController]
[Route("api/v1/[controller]")]
public class FacadeController : ControllerBase
{
    private readonly IMediator _mediator;

    public FacadeController(IMediator mediator) 
        => _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<GetFrontPageAggregationResponse>> GetFrontPageAggregation()
    {
       var result = await _mediator.Send(new GetFrontPageAggregationCommand());
       return Ok(result);
    }
}