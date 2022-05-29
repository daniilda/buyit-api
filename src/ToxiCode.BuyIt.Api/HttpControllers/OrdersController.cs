using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToxiCode.BuyIt.Api.Handlers.Orders.PlaceOrder.Dtos;
using ToxiCode.BuyIt.Api.Platform;

namespace ToxiCode.BuyIt.Api.HttpControllers;

[ApiController]
[Route("api/v1/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator) 
        => _mediator = mediator;

    [HttpPost]
    [TokenAuthenticationFilter]
    public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{id:long}")]
    [TokenAuthenticationFilter]
    public async Task<IActionResult> CancelOrder([FromRoute] long id)
    {
        await Task.Delay(1);
        return Ok();
    }

    [HttpGet("{id:long}")]
    [TokenAuthenticationFilter]
    public async Task<IActionResult> GetOrder([FromRoute] long id)
    {
        await Task.Delay(1);
        return Ok();
    }

    [HttpGet("{userId:guid}")]
    [TokenAuthenticationFilter]
    public async Task<IActionResult> GetOrdersByUsedId([FromRoute] Guid userId)
    {
        await Task.Delay(1);
        return Ok();
    }

}