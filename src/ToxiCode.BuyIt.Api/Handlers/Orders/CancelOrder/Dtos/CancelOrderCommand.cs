using MediatR;

namespace ToxiCode.BuyIt.Api.Handlers.Orders.CancelOrder.Dtos;

public class CancelOrderCommand : IRequest
{
    public long OrderId { get; set; }
}