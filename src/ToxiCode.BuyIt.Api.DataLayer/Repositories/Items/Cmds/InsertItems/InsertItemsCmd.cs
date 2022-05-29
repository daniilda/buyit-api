using ToxiCode.BuyIt.Api.Dtos;

namespace ToxiCode.BuyIt.Api.DataLayer.Repositories.Items.Cmds.InsertItems;

public class InsertItemsCmd
{
    public IEnumerable<ItemToAdd> Items { get; init; } = Array.Empty<ItemToAdd>();
}