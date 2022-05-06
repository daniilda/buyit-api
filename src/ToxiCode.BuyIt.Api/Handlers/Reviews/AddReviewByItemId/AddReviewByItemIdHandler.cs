using MediatR;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Reviews;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Reviews.Cmds.InsertReviewByItemId;
using ToxiCode.BuyIt.Api.Handlers.Reviews.AddReviewByItemId.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Reviews.AddReviewByItemId;

public class AddReviewByItemIdHandler : AsyncRequestHandler<AddReviewByItemIdCommand>
{
    private readonly ReviewsRepository _repository;

    public AddReviewByItemIdHandler(ReviewsRepository repository) 
        => _repository = repository;

    protected override Task Handle(AddReviewByItemIdCommand request, CancellationToken cancellationToken)
    {
        var cmd = new InsertReviewByItemIdCmd(request.Review, request.ItemId);
        return _repository.InsertReviewByItemId(cmd, cancellationToken);
    }
}