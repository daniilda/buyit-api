using ToxiCode.BuyIt.Api.Dtos;

namespace ToxiCode.BuyIt.Api.DataLayer.Repositories.Items.Cmds.UpdateItems;

public record UpdateItemsCmd(IEnumerable<Item> Items);