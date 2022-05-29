using AutoMapper;
using MediatR;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Orders;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Orders.Cmds.InsertOrder;
using ToxiCode.BuyIt.Api.GrpcClients;
using ToxiCode.BuyIt.Api.Handlers.Orders.PlaceOrder.Dtos;
using ToxiCode.BuyIt.Logistics.Api.Grpc;

namespace ToxiCode.BuyIt.Api.Handlers.Orders.PlaceOrder;

public class PlaceOrderHandler : AsyncRequestHandler<PlaceOrderCommand>
{
    private readonly LogisticsApiGrpcClient _client;
    private readonly OrdersRepository _repository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _accessor;

    public PlaceOrderHandler(
        LogisticsApiGrpcClient client,
        OrdersRepository repository,
        IMapper mapper,
        IHttpContextAccessor accessor)
    {
        _client = client;
        _repository = repository;
        _mapper = mapper;
        _accessor = accessor;
    }

    protected override async Task Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
    {
        var userId = _accessor.HttpContext!.Items["UserId"]!.ToString()!;

        var grpcRequest = _mapper.Map<AddOrderRequest>(request, opt =>
            opt.AfterMap((_, x) => x.UserId = userId));
        var grpcResponse = await _client.AddOrderAsync(grpcRequest, cancellationToken);

        var insertCmd = new InsertOrderCmd
        {
            OrderId = (long) grpcResponse.OrderId!,
            UserId = Guid.Parse(userId)
        };
        await _repository.InsertOrder(insertCmd, cancellationToken);
    }
}