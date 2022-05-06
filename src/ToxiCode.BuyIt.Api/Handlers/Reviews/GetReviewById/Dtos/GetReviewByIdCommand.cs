using MediatR;

namespace ToxiCode.BuyIt.Api.Handlers.Reviews.GetReviewById.Dtos;

public record GetReviewByIdCommand(long Id) : IRequest<GetReviewByIdResponse>;