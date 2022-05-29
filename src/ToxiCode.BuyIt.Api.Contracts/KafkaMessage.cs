using System.ComponentModel.DataAnnotations;

namespace ToxiCode.BuyIt.Api.Contracts;

public class KafkaMessage
{
    public Action Action { get; set; }

    [Required]
    public string NotificationMessage { get; set; } = null!;
}