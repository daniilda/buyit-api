using ToxiCode.BuyIt.Api.Dtos;

namespace ToxiCode.BuyIt.Api.DataLayer.Repositories.Items.Cmds.GetItemsByAggregate;

public class GetItemsByAggregateCmdResponse
{
    public IEnumerable<Item> Items { get; set; } = Array.Empty<Item>();
}