using ToxiCode.BuyIt.Api.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Items.GetItemsById.Dtos;

public class GetItemsByIdResponse
{
    public Item[] Items { get; init; } = null!;
}