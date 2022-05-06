using MediatR;
using ToxiCode.BuyIt.Api.Dtos.Pagination;

namespace ToxiCode.BuyIt.Api.Handlers.Reviews.GetReviewsByItemId.Dtos;

public record GetReviewsByItemIdCommand(long ItemId, Pagination Pagination) : IRequest<GetReviewsByItemIdResponse>;