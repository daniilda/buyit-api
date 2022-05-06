using ToxiCode.BuyIt.Api.Dtos;
using ToxiCode.BuyIt.Api.Dtos.Pagination;

namespace ToxiCode.BuyIt.Api.DataLayer.Repositories.Reviews.Cmds.GetReviewsByItemId;

public record GetReviewsByItemIdCmdResponse(IEnumerable<Review> Reviews, PaginationResponse Pagination);