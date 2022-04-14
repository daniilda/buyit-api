using AutoMapper;
using MediatR;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Items;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Items.Cmds.GetItems;
using ToxiCode.BuyIt.Api.Handlers.Items.GetItems.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Items.GetItems;

public class GetItemsHandler : IRequestHandler<GetItemsWithFilterCommand, GetItemsWithFilterResponse>
{
    private readonly ItemsRepository _repository;
    private readonly IMapper _mapper;

    public GetItemsHandler(ItemsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetItemsWithFilterResponse> Handle(GetItemsWithFilterCommand request,
        CancellationToken cancellationToken)
    {
        var cmd = _mapper.Map<GetItemsCmd>(request);
        var result = await _repository.GetItems(cmd, cancellationToken);
        return _mapper.Map<GetItemsWithFilterResponse>(result);
    }
}