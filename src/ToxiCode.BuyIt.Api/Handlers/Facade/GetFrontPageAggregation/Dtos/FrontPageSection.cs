using ToxiCode.BuyIt.Api.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Facade.GetFrontPageAggregation.Dtos;

public class FrontPageSection
{
    public Banner Banner { get; init; } = null!;

    public IEnumerable<Item> Items { get; init; } = null!;
}