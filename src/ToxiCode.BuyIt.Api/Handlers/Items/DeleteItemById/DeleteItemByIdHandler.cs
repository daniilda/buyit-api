using MediatR;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Items;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Items.Cmds.MarkItemsForDeletion;
using ToxiCode.BuyIt.Api.Handlers.Items.DeleteItemById.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Items.DeleteItemById;

public class DeleteItemByIdHandler : AsyncRequestHandler<DeleteItemByIdCommand>
{
    private readonly ItemsRepository _repository;

    public DeleteItemByIdHandler(ItemsRepository repository) => _repository = repository;

    protected override Task Handle(DeleteItemByIdCommand request, CancellationToken cancellationToken)
    {
        var cmd = new MarkItemsForDeletionCmd(new[] {request.Id});
        return _repository.MarkItemsForDeletionAsync(cmd, cancellationToken);
    }
}