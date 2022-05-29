using MediatR;

namespace ToxiCode.BuyIt.Api.Handlers.Orders.GetOrder.Dtos;

public class GetOrderCommand : IRequest<GetOrderResponse>
{
    public long OrderId { get; set; }
}