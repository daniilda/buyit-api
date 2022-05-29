using ToxiCode.BuyIt.Api.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Orders.GetOrdersByUserId.Dtos;

public class GetOrdersByUserIdResponse
{
    public IEnumerable<Order> Orders { get; set; } = null!;
}