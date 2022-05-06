using ToxiCode.BuyIt.Api.Dtos;
using ToxiCode.BuyIt.Api.Dtos.Pagination;

namespace ToxiCode.BuyIt.Api.Handlers.Reviews.GetReviewsByItemId.Dtos;

public class GetReviewsByItemIdResponse
{
    public IEnumerable<Review> Reviews = Array.Empty<Review>();

    public PaginationResponse Pagination = null!;
}