using ToxiCode.BuyIt.Api.Dtos;
using ToxiCode.BuyIt.Api.Dtos.Pagination;

namespace ToxiCode.BuyIt.Api.Handlers.Items.GetItems.Dtos;

public class GetItemsWithFilterResponse
{
    public Item[] Items { get; init; } = null!;

    public PaginationResponse Pagination { get; init; } = null!;
}