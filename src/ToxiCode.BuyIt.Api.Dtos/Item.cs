namespace ToxiCode.BuyIt.Api.Dtos;

public class Item
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;
    
    public Guid OwnerId { get; set; }
    
    public decimal Price { get; set; }
    
    public int InStockAmount { get; set; }

    public IEnumerable<long> CategoryIds { get; set; } = Array.Empty<long>();

    public Rating Rating { get; set; } = null!;

    public IEnumerable<string> ImageUrls { get; set; } = Array.Empty<string>();
    
    public DateTime CreatedAt { get; set; }
}