using ToxiCode.BuyIt.Api.Dtos.Enums;

namespace ToxiCode.BuyIt.Api.Dtos;

public class Sorting
{
    public SortingMode Mode { get; init; }
    
    public SortingType Type { get; init; }
}