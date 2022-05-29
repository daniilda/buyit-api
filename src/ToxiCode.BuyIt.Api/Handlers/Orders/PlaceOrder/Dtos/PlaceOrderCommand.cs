using MediatR;
using ToxiCode.BuyIt.Api.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Orders.PlaceOrder.Dtos;

public class PlaceOrderCommand : IRequest
{
    public IEnumerable<ItemInOrder> ItemsInOrder { get; set; } = null!;

    public string DstPlace { get; set; } = null!;
}