using MediatR;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Orders;
using ToxiCode.BuyIt.Api.Dtos;
using ToxiCode.BuyIt.Api.GrpcClients;
using ToxiCode.BuyIt.Api.Handlers.Orders.GetOrdersByUserId.Dtos;
using ToxiCode.BuyIt.Logistics.Api.Grpc;
using Order = ToxiCode.BuyIt.Api.Dtos.Order;

namespace ToxiCode.BuyIt.Api.Handlers.Orders.GetOrdersByUserId;

public class GetOrdersByUserIdHandler : IRequestHandler<GetOrdersByUserIdCommand, GetOrdersByUserIdResponse>
{
    private readonly LogisticsApiGrpcClient _client;
    private readonly IHttpContextAccessor _accessor;
    private readonly OrdersRepository _repository;

    public GetOrdersByUserIdHandler(
        LogisticsApiGrpcClient client, 
        IHttpContextAccessor accessor,
        OrdersRepository repository)
    {
        _client = client;
        _accessor = accessor;
        _repository = repository;
    }

    public async Task<GetOrdersByUserIdResponse> Handle(GetOrdersByUserIdCommand request,
        CancellationToken cancellationToken)
    {
        var userId = _accessor.HttpContext!.Items["UserId"]!.ToString()!;

        var grpcRequest = new GetOrdersByBuyerIdRequest
        {
            BuyerId = userId
        };
        try
        {
            var grpcResponse = await _client.GetOrdersAsync(grpcRequest, cancellationToken);
            return new GetOrdersByUserIdResponse
            {
                Orders = grpcResponse.Orders.Select(x => new Order
                {
                    DstPlace = new Place
                    {
                        Id = x.ToAddressId
                    },
                    ItemsIds = x.Items.Select(y => new ItemInOrder
                    {
                        Amount = y.Count,
                        ItemId = y.ItemId
                    }),
                    OrderId = x.OrderId,
                    OrderStatus = x.OrderStatus
                })
            };
        }
        catch
        {
            var result = await _repository.GetOrdersIdsByUserId(Guid.Parse(userId), cancellationToken);
            return new GetOrdersByUserIdResponse
            {
                Orders = result.Select(x => new Order
                {
                    OrderId = x
                })
            };
        }
    }
}