namespace ToxiCode.BuyIt.Api.Contracts;

public class OrderStatusChangedNotificationMessage
{
    public long OrderId { get; set; }
    
    public OrderStatus OrderStatus { get; set; }
}