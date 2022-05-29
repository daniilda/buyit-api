using MediatR;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Items;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Items.Cmds.GetItem;
using ToxiCode.BuyIt.Api.GrpcClients;
using ToxiCode.BuyIt.Api.Handlers.Items.GetItemById.Dtos;
using ToxiCode.BuyIt.Logistics.Api.Grpc;

namespace ToxiCode.BuyIt.Api.Handlers.Items.GetItemById;

public class GetItemByIdHandler : IRequestHandler<GetItemByIdCommand, GetItemByIdResponse>
{
    private readonly ItemsRepository _repository;
    private readonly LogisticsApiGrpcClient _client;

    public GetItemByIdHandler(ItemsRepository repository, LogisticsApiGrpcClient client)
    {
        _repository = repository;
        _client = client;
    }

    public async Task<GetItemByIdResponse> Handle(GetItemByIdCommand request, CancellationToken cancellationToken)
    {
        var grpcRequest = new GetItemsByIdsRequest()
        {
            ItemsIds = {request.Id}
        };
        var grpcResponse = _client.GetItemsAsync(grpcRequest, cancellationToken);
        var cmd = new GetItemByIdCmd(request.Id);
        var result = await _repository.GetItemById(cmd, cancellationToken);
        result.Item.InStockAmount = grpcResponse.Result.Items.FirstOrDefault()?.AvailableCount ?? 0;
        return new GetItemByIdResponse(result.Item);
    }
}