namespace ToxiCode.BuyIt.Api.DataLayer.Repositories.Items.Cmds.DeleteItems;

public record DeleteItemsCmd(IEnumerable<long> ItemsIds);