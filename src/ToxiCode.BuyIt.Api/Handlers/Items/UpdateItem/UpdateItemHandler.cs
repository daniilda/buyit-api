using AutoMapper;
using MediatR;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Items;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Items.Cmds.UpdateItems;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Pictures;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Pictures.Cmds.UpdatePicturesForItem;
using ToxiCode.BuyIt.Api.Handlers.Items.UpdateItem.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Items.UpdateItem;

public class UpdateItemHandler : AsyncRequestHandler<UpdateItemCommand>
{
    private readonly ItemsRepository _itemsRepository;
    private readonly PicturesRepository _picturesRepository;
    private readonly IMapper _mapper;


    public UpdateItemHandler(
        ItemsRepository itemsRepository, 
        PicturesRepository picturesRepository, 
        IMapper mapper)
    {
        _itemsRepository = itemsRepository;
        _picturesRepository = picturesRepository;
        _mapper = mapper;
    }

    protected override async Task Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var itemsCmd = new UpdateItemsCmd(new[] {request.Item});
        await _itemsRepository.UpdateItemsAsync(itemsCmd, cancellationToken);

        var picturesCmd = _mapper.Map<UpdatePicturesForItemCmd>(request);
        await _picturesRepository.UpdatePicturesForItemAsync(picturesCmd, cancellationToken);
    }
}