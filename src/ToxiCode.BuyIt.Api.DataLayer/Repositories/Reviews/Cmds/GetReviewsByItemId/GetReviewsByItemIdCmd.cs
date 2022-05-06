using ToxiCode.BuyIt.Api.Dtos.Pagination;

namespace ToxiCode.BuyIt.Api.DataLayer.Repositories.Reviews.Cmds.GetReviewsByItemId;

public record GetReviewsByItemIdCmd(long ItemId, Pagination Pagination);