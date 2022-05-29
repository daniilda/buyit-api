namespace ToxiCode.BuyIt.Api.Handlers.Facade.GetFrontPageAggregation.Dtos;

public class GetFrontPageAggregationResponse
{
    public IEnumerable<FrontPageSection> Sections { get; set; } = Array.Empty<FrontPageSection>();
}