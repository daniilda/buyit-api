using MediatR;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Reviews;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Reviews.Cmds.GetReviewsByItemId;
using ToxiCode.BuyIt.Api.Handlers.Reviews.GetReviewById.Dtos;
using ToxiCode.BuyIt.Api.Handlers.Reviews.GetReviewsByItemId.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Reviews.GetReviewsByItemId;

public class GetReviewsByItemIdHandler : IRequestHandler<GetReviewsByItemIdCommand, GetReviewsByItemIdResponse>
{
    private readonly ReviewsRepository _repository;

    public GetReviewsByItemIdHandler(ReviewsRepository repository)
        => _repository = repository;

    public async Task<GetReviewsByItemIdResponse> Handle(GetReviewsByItemIdCommand request,
        CancellationToken cancellationToken)
    {
        var cmd = new GetReviewsByItemIdCmd(request.ItemId, request.Pagination);
        var result = await _repository.GetReviewsByItemIdAsync(cmd, cancellationToken);
        return new GetReviewsByItemIdResponse
        {
            Reviews = result.Reviews,
            Pagination = result.Pagination
        };
    }
}