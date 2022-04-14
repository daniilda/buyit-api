namespace ToxiCode.BuyIt.Api.DataLayer.Repositories.Items.Cmds.MarkItemsForDeletion;

public record MarkItemsForDeletionCmd(IEnumerable<long> ItemsIds);