using AutoMapper;
using MediatR;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Items;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Items.Cmds.InsertItems;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Pictures;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Pictures.Cmds.InsertPicturesForItems;
using ToxiCode.BuyIt.Api.Handlers.Items.AddItem.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Items.AddItem;

public class AddItemHandler : AsyncRequestHandler<AddItemCommand>
{
    private readonly ItemsRepository _itemsRepository;
    private readonly PicturesRepository _picturesRepository;
    private readonly IMapper _mapper;

    public AddItemHandler(
        ItemsRepository itemsRepository, 
        PicturesRepository picturesRepository, 
        IMapper mapper)
    {
        _itemsRepository = itemsRepository;
        _picturesRepository = picturesRepository;
        _mapper = mapper;
    }

    protected override async Task Handle(AddItemCommand request, CancellationToken cancellationToken)
    {
        // TODO: Хождение в Logistics Api получение Id-шника.
        var itemsCmd = _mapper.Map<InsertItemsCmd>(request);
        await _itemsRepository.InsertItemsAsync(itemsCmd, cancellationToken);

        if (request.Item.Pictures.Any())
        {
            var picturesCmd = _mapper.Map<InsertPicturesForItemCmd>(request);
            await _picturesRepository.InsertPicturesForItemAsync(picturesCmd, cancellationToken);
        }
    }
}