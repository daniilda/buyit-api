using AutoMapper;
using MediatR;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Images;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Images.Cmds.InsertPicturesForItems;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Items;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Items.Cmds.InsertItems;
using ToxiCode.BuyIt.Api.GrpcClients;
using ToxiCode.BuyIt.Api.Handlers.Items.AddItem.Dtos;
using ToxiCode.BuyIt.Logistics.Api.Grpc;

namespace ToxiCode.BuyIt.Api.Handlers.Items.AddItem;

public class AddItemHandler : AsyncRequestHandler<AddItemCommand>
{
    private readonly ItemsRepository _itemsRepository;
    private readonly ImagesRepository _imagesRepository;
    private readonly LogisticsApiGrpcClient _client;
    private readonly IMapper _mapper;

    public AddItemHandler(
        ItemsRepository itemsRepository, 
        ImagesRepository imagesRepository, 
        IMapper mapper, 
        LogisticsApiGrpcClient client)
    {
        _itemsRepository = itemsRepository;
        _imagesRepository = imagesRepository;
        _mapper = mapper;
        _client = client;
    }

    protected override async Task Handle(AddItemCommand request, CancellationToken cancellationToken)
    {
        var urls = await _imagesRepository.GetUrlsByImageIds(request.Images.ToArray(), cancellationToken);
        var addItem = _mapper.Map<Logistics.Api.Grpc.AddItem>(request);
        addItem.ImgUrl = urls.FirstOrDefault();

        var grpcRequest = new AddItemRequest()
        {
            AddItem = addItem
        };
        var grpcResult = await _client.AddItemsAsync(grpcRequest, cancellationToken);

        var itemId = grpcResult.AddItemResult.ItemId;

        var itemToAdd = _mapper.Map<ItemToAdd>(request);
        itemToAdd.Id = itemId;
        var itemsCmd = new InsertItemsCmd()
        {
            Items = new[] {itemToAdd}
        };
        await _itemsRepository.InsertItemsAsync(itemsCmd, cancellationToken);

        if (request.Images.Any())
        {
            var picturesCmd = _mapper.Map<InsertPicturesForItemCmd>(itemToAdd);
            await _imagesRepository.InsertImagesForItemAsync(picturesCmd, cancellationToken);
        }
    }
}