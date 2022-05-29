using ToxiCode.BuyIt.Logistics.Api.Grpc;

namespace ToxiCode.BuyIt.Api.GrpcClients;

public class LogisticsApiGrpcClient
{
    private readonly ItemsService.ItemsServiceClient _itemsClient;
    private readonly OrdersService.OrdersServiceClient _ordersClient;

    public LogisticsApiGrpcClient(
        ItemsService.ItemsServiceClient itemsClient, 
        OrdersService.OrdersServiceClient ordersClient)
    {
        _itemsClient = itemsClient;
        _ordersClient = ordersClient;
    }

    public async Task<GetItemsByIdsResponse> GetItemsAsync(GetItemsByIdsRequest request, CancellationToken cancellationToken) 
        => await _itemsClient.GetItemsByIdsAsync(request, deadline: CalcDeadline(), cancellationToken: cancellationToken);

    public async Task<AddItemResponse> AddItemsAsync(AddItemRequest request, CancellationToken cancellationToken)
        => await _itemsClient.AddItemAsync(request, deadline: CalcDeadline(), cancellationToken: cancellationToken);

    public async Task<ChangeItemResponse> ChangeItemsAsync(ChangeItemRequest request,
        CancellationToken cancellationToken)
        => await _itemsClient.ChangeItemAsync(request, deadline: CalcDeadline(), cancellationToken: cancellationToken);

    public async Task<GetOrdersByBuyerIdResponse> GetOrdersAsync(GetOrdersByBuyerIdRequest request, CancellationToken cancellationToken)
        => await _ordersClient.GetOrdersByBuyerIdAsync(request, deadline: CalcDeadline(), cancellationToken: cancellationToken);

    public async Task<AddOrderResponse> AddOrderAsync(AddOrderRequest request, CancellationToken cancellationToken)
        => await _ordersClient.AddOrderAsync(request, deadline: CalcDeadline(), cancellationToken: cancellationToken);

    public async Task<OrderPaidResponse> MarkOrderAsPaidAsync(OrderPaidRequest request,
        CancellationToken cancellationToken)
        => await _ordersClient.OrderPaidAsync(request, deadline: CalcDeadline(), cancellationToken: cancellationToken);

    public async Task<CancelOrderResponse> CancelOrderAsync(CancelOrderRequest request,
        CancellationToken cancellationToken)
        => await _ordersClient.CancelOrderAsync(request, deadline: CalcDeadline(),
            cancellationToken: cancellationToken);

    public async Task<AddArticlesResponse> AddArticlesAsync(AddArticlesRequest request,
        CancellationToken cancellationToken)
        => await _itemsClient.AddArticlesAsync(request, deadline: CalcDeadline(), cancellationToken: cancellationToken);

    private static DateTime CalcDeadline() 
        => DateTime.UtcNow.AddSeconds(5);
}