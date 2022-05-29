using ToxiCode.BuyIt.Api.Dtos;

namespace ToxiCode.BuyIt.Api.DataLayer.Repositories.Items.Cmds.GetItemsById;

public class GetItemsByIdCmdResponse
{
    public Item[] Items { get; init; } = Array.Empty<Item>();
}