using MediatR;
using ToxiCode.BuyIt.Api.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Items.AddItem.Dtos;

public class AddItemCommand : IRequest
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;
    
    public Guid OwnerId { get; set; }
    
    public decimal Weight { get; set; }
    
    public decimal Length { get; set; }
    
    public decimal Width { get; set; }
    
    public decimal Height { get; set; }
    
    public decimal Price { get; set; }
    
    public int InStockAmount { get; set; }

    public IEnumerable<long> CategoryIds { get; set; } = Array.Empty<long>();

    public IEnumerable<Guid> Images { get; set; } = Array.Empty<Guid>();
}