using MediatR;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Items;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Items.Cmds.GetItem;
using ToxiCode.BuyIt.Api.Handlers.Items.GetItemById.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Items.GetItemById;

public class GetItemByIdHandler : IRequestHandler<GetItemByIdCommand, GetItemByIdResponse>
{
    private readonly ItemsRepository _repository;

    public GetItemByIdHandler(ItemsRepository repository) 
        => _repository = repository;

    public async Task<GetItemByIdResponse> Handle(GetItemByIdCommand request, CancellationToken cancellationToken)
    {
        var cmd = new GetItemByIdCmd(request.Id);
        var result = await _repository.GetItemById(cmd, cancellationToken);
        return new GetItemByIdResponse(result.Item);
    }
}