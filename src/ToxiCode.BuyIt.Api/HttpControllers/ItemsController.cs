using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToxiCode.BuyIt.Api.Dtos;
using ToxiCode.BuyIt.Api.Handlers.Items.AddItem.Dtos;
using ToxiCode.BuyIt.Api.Handlers.Items.DeleteItemById.Dtos;
using ToxiCode.BuyIt.Api.Handlers.Items.GetItemById.Dtos;
using ToxiCode.BuyIt.Api.Handlers.Items.GetItems.Dtos;
using ToxiCode.BuyIt.Api.Handlers.Items.UpdateItem.Dtos;

namespace ToxiCode.BuyIt.Api.HttpControllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemsController(IMediator mediator) 
        => _mediator = mediator;

    [HttpGet("{id:long}")]
    public async Task<ActionResult<GetItemByIdResponse>> GetItem([FromRoute]long id)
    {
        var command = new GetItemByIdCommand(id);
        var response = await _mediator.Send(command);
        return Ok(response);
    }
    
    [HttpGet]
    public async Task<ActionResult<GetItemsWithFilterResponse>> GetItems(
        [FromQuery] Filter? filter, 
        [FromQuery] Dtos.Pagination.Pagination? pagination, 
        [FromQuery] Sorting? sorting)
    {
        var command = new GetItemsWithFilterCommand(filter, pagination, sorting);
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddItem([FromBody] AddItemCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateItem([FromBody] UpdateItemCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteItem([FromRoute] long id)
    {
        var command = new DeleteItemByIdCommand(id);
        await _mediator.Send(command);
        return Ok();
    }
}