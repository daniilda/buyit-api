using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ToxiCode.BuyIt.Api.HttpControllers;

[ApiController]
[Route("v1/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator) 
        => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> PlaceOrder()
    {
        await Task.Delay(1);
        return Ok();
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> UpdateOrder([FromRoute] long id)
    {
        await Task.Delay(1);
        return Ok();
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteOrder([FromRoute] long id)
    {
        await Task.Delay(1);
        return Ok();
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetOrder([FromRoute] long id)
    {
        await Task.Delay(1);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        await Task.Delay(1);
        return Ok();
    }

}