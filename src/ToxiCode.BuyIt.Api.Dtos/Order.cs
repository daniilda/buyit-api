using ToxiCode.BuyIt.Logistics.Api.Grpc;

namespace ToxiCode.BuyIt.Api.Dtos;

public class Order
{
    public long OrderId { get; set; }
    
    public OrderStatus OrderStatus { get; set; }

    public IEnumerable<ItemInOrder> ItemsIds { get; set; } = Array.Empty<ItemInOrder>();

    public Place? DstPlace { get; set; }
}