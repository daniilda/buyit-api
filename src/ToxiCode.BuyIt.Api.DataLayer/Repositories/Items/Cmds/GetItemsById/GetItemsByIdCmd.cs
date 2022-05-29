namespace ToxiCode.BuyIt.Api.DataLayer.Repositories.Items.Cmds.GetItemsById;

public class GetItemsByIdCmd
{
    public IEnumerable<long> Ids { get; set; } = Array.Empty<long>();
}