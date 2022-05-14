namespace ToxiCode.BuyIt.Api.Contracts;

public class CreatedItemNotification
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;
    
    public Guid OwnerId { get; set; }
    
    public decimal Price { get; set; }

    public IEnumerable<Image> Images { get; set; } = Array.Empty<Image>();
}