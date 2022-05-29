using FluentMigrator.Model;
using MediatR;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Items;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Items.Cmds.GetItemsByAggregate;
using ToxiCode.BuyIt.Api.GrpcClients;
using ToxiCode.BuyIt.Api.Handlers.Facade.GetFrontPageAggregation.Dtos;
using ToxiCode.BuyIt.Logistics.Api.Grpc;

namespace ToxiCode.BuyIt.Api.Handlers.Facade.GetFrontPageAggregation;

public class
    GetFrontPageAggregationHandler : IRequestHandler<GetFrontPageAggregationCommand, GetFrontPageAggregationResponse>
{
    private readonly ItemsRepository _repository;
    private readonly LogisticsApiGrpcClient _client;

    public GetFrontPageAggregationHandler(ItemsRepository repository, LogisticsApiGrpcClient client)
    {
        _repository = repository;
        _client = client;
    }

    public async Task<GetFrontPageAggregationResponse> Handle(GetFrontPageAggregationCommand request,
        CancellationToken cancellationToken)
    {
        // Хардкод, ибо мне очень лень продумывать эту фичу в реляционной модели
        var sections = new List<FrontPageSection>();
        for (var i = 1; i < 4; i++)
        {
            var cmd = new GetItemsByAggregateCmd
            {
                CategoryId = i
            };
            var result = await _repository.GetItems(cmd, cancellationToken);
            var items = result.Items.ToList();
            var mappedRequest = new GetItemsByIdsRequest
            {
                ItemsIds = {result.Items.Select(x => x.Id)}
            };
            var grpcResponse = await _client.GetItemsAsync(mappedRequest, cancellationToken);
            foreach (var item in items.Where(item => grpcResponse.Items.Any(x => x.ItemId == item.Id)))
                item.InStockAmount = grpcResponse.Items.First(x => x.ItemId == item.Id).AvailableCount;

            var section = new FrontPageSection
            {
                Items = result.Items,
                Banner = Banner.GetByCategoryKey(i)
            };
            sections.Add(section);
        }

        return new GetFrontPageAggregationResponse
        {
            Sections = sections
        };
    }
}