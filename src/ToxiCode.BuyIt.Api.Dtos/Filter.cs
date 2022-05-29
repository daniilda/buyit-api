using ToxiCode.BuyIt.Api.Dtos.Enums;

namespace ToxiCode.BuyIt.Api.Dtos;

public class Filter
{
    public string Search = string.Empty;
    
    public int PriceMax { get; init; }
    
    public int PriceMin { get; init; }
    
    public int ReviewCountMin { get; init; }
    
    public int ReviewCountMax { get; init; }
    
    public DeliveryDeadline DeliveryDeadline { get; init; }

    public IEnumerable<long> Categories { get; init; } = Array.Empty<long>();
}