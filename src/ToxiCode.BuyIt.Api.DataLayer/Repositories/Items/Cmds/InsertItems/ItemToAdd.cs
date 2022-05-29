using ToxiCode.BuyIt.Logistics.Api.Grpc;

namespace ToxiCode.BuyIt.Api.DataLayer.Repositories.Items.Cmds.InsertItems;

public class ItemToAdd
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;
    
    public Guid OwnerId { get; set; }
    
    public decimal Price { get; set; }
    
    public int InStockAmount { get; set; }

    public IEnumerable<long> CategoryIds { get; set; } = Array.Empty<long>();

    public IEnumerable<Guid> Images { get; set; } = Array.Empty<Guid>();
}