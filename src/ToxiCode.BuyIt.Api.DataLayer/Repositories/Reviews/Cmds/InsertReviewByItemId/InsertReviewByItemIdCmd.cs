using ToxiCode.BuyIt.Api.Dtos;

namespace ToxiCode.BuyIt.Api.DataLayer.Repositories.Reviews.Cmds.InsertReviewByItemId;

public record InsertReviewByItemIdCmd(Review Review, long ItemId);