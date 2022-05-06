using MediatR;
using ToxiCode.BuyIt.Api.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Reviews.AddReviewByItemId.Dtos;

public record AddReviewByItemIdCommand(Review Review, long ItemId) : IRequest;