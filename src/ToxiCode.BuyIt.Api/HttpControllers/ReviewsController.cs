using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToxiCode.BuyIt.Api.Dtos.Pagination;
using ToxiCode.BuyIt.Api.Handlers.Reviews.AddReviewByItemId.Dtos;
using ToxiCode.BuyIt.Api.Handlers.Reviews.GetReviewById.Dtos;
using ToxiCode.BuyIt.Api.Handlers.Reviews.GetReviewsByItemId.Dtos;

namespace ToxiCode.BuyIt.Api.HttpControllers;

[ApiController]
[Route("v1/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReviewsController(IMediator mediator) 
        => _mediator = mediator;

    [HttpGet("/{id:long}")]
    public async Task<ActionResult> GetReview([FromRoute] long id)
    {
        var command = new GetReviewByIdCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("by-item-id/{itemId:long}")]
    public async Task<ActionResult<GetReviewsByItemIdResponse>> GetReviewsByItemId([FromRoute] long itemId, [FromQuery] Pagination pagination)
    {
        var command = new GetReviewsByItemIdCommand(itemId, pagination);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("by-item-id/")]
    public async Task<ActionResult> AddReview(AddReviewByItemIdCommand command)
    {
        await _mediator.Send(command);
        return Ok(); 
    }
}
