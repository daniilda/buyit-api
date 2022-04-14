namespace ToxiCode.BuyIt.Api.Dtos;

public class Item
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;
    
    public Guid OwnerId { get; set; }
    
    public decimal Price { get; set; }

    public Rating Rating { get; set; } = null!;

    public IEnumerable<Picture> Pictures { get; set; } = Array.Empty<Picture>();
    
    public DateTime CreatedAt { get; set; }
}