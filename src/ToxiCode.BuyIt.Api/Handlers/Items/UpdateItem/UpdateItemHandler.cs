using AutoMapper;
using MediatR;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Images;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Images.Cmds.UpdatePicturesForItem;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Items;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Items.Cmds.UpdateItems;
using ToxiCode.BuyIt.Api.Handlers.Items.UpdateItem.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Items.UpdateItem;

public class UpdateItemHandler : AsyncRequestHandler<UpdateItemCommand>
{
    private readonly ItemsRepository _itemsRepository;
    private readonly ImagesRepository _imagesRepository;
    private readonly IMapper _mapper;


    public UpdateItemHandler(
        ItemsRepository itemsRepository, 
        ImagesRepository imagesRepository, 
        IMapper mapper)
    {
        _itemsRepository = itemsRepository;
        _imagesRepository = imagesRepository;
        _mapper = mapper;
    }

    protected override async Task Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var itemsCmd = new UpdateItemsCmd(new[] {request.Item});
        await _itemsRepository.UpdateItemsAsync(itemsCmd, cancellationToken);

        var picturesCmd = _mapper.Map<UpdatePicturesForItemCmd>(request);
        await _imagesRepository.UpdatePicturesForItemAsync(picturesCmd, cancellationToken);
    }
}