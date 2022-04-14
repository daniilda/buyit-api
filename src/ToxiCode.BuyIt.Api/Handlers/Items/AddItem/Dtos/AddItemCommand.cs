using MediatR;
using ToxiCode.BuyIt.Api.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Items.AddItem.Dtos;

public class AddItemCommand : IRequest
{
    public Item Item { get; init; } = null!;
}