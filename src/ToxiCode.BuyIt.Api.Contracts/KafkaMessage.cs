namespace ToxiCode.BuyIt.Api.Contracts;

public class KafkaMessage
{
    public Action Action { get; set; }
    
    public CreatedItemNotification? CreatedItemNotification { get; set; }
}