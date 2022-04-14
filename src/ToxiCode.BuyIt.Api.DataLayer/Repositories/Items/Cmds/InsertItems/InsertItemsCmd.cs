using ToxiCode.BuyIt.Api.Dtos;

namespace ToxiCode.BuyIt.Api.DataLayer.Repositories.Items.Cmds.InsertItems;

public class InsertItemsCmd
{
    public Item[] Items { get; init; } = Array.Empty<Item>();
}