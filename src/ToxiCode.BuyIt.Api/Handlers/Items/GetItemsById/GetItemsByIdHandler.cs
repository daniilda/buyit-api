using AutoMapper;
using JetBrains.Annotations;
using MediatR;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Items;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Items.Cmds.GetItemsById;
using ToxiCode.BuyIt.Api.Handlers.Items.GetItemsById.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Items.GetItemsById;

[UsedImplicitly]
public class GetItemsByIdHandler : IRequestHandler<GetItemsByIdCommand, GetItemsByIdResponse>
{
    private readonly ItemsRepository _repository;
    private readonly IMapper _mapper;
    
    public GetItemsByIdHandler(ItemsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetItemsByIdResponse> Handle(GetItemsByIdCommand request, CancellationToken cancellationToken)
    {
        var cmd = _mapper.Map<GetItemsByIdCmd>(request);
        var result = await _repository.GetItems(cmd, cancellationToken);
        return new GetItemsByIdResponse
        {
            Items = result.Items
        };
    }
}