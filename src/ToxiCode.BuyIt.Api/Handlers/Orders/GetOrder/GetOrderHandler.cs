using MediatR;
using ToxiCode.BuyIt.Api.Handlers.Orders.GetOrder.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Orders.GetOrder;

public class GetOrderHandler : IRequestHandler<GetOrderCommand, GetOrderResponse>
{
    public Task<GetOrderResponse> Handle(GetOrderCommand request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}