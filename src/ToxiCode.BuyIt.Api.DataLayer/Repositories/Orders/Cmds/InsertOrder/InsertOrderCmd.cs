namespace ToxiCode.BuyIt.Api.DataLayer.Repositories.Orders.Cmds.InsertOrder;

public class InsertOrderCmd
{
    public long OrderId { get; init; }
    
    public Guid UserId { get; init; }
}