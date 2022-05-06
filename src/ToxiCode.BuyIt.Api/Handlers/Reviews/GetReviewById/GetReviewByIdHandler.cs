using MediatR;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Reviews;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Reviews.Cmds.GetReview;
using ToxiCode.BuyIt.Api.Handlers.Reviews.GetReviewById.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Reviews.GetReviewById;

public class GetReviewByIdHandler : IRequestHandler<GetReviewByIdCommand, GetReviewByIdResponse>
{
    private readonly ReviewsRepository _repository;

    public GetReviewByIdHandler(ReviewsRepository repository)
        => _repository = repository;

    public async Task<GetReviewByIdResponse> Handle(GetReviewByIdCommand request, CancellationToken cancellationToken)
    {
        var cmd = new GetReviewCmd(request.Id);
        var result = await _repository.GetReviewAsync(cmd, cancellationToken);
        return new GetReviewByIdResponse(result.Review);
    }
}