using JetBrains.Annotations;
using MediatR;
using ToxiCode.BuyIt.Api.GrpcClients;
using ToxiCode.BuyIt.Api.Handlers.Orders.CancelOrder.Dtos;
using ToxiCode.BuyIt.Logistics.Api.Grpc;

namespace ToxiCode.BuyIt.Api.Handlers.Orders.CancelOrder;

[UsedImplicitly]
public class CancelOrderHandler : AsyncRequestHandler<CancelOrderCommand>
{
    private readonly LogisticsApiGrpcClient _client;

    public CancelOrderHandler(LogisticsApiGrpcClient client)
        => _client = client;

    protected override Task Handle(CancelOrderCommand request, CancellationToken cancellationToken)
    {
        var mappedRequest = new CancelOrderRequest
        {
            OrderId = request.OrderId
        };
        return _client.CancelOrderAsync(mappedRequest, cancellationToken);
    }
}