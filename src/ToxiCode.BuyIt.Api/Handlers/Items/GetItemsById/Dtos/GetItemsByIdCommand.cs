using MediatR;

namespace ToxiCode.BuyIt.Api.Handlers.Items.GetItemsById.Dtos;

public class GetItemsByIdCommand : IRequest<GetItemsByIdResponse>
{
    public IEnumerable<long> Ids { get; set; } = Array.Empty<long>();
}