using System.Text;
using Confluent.Kafka;
using JetBrains.Annotations;
using Newtonsoft.Json;
using ToxiCode.BuyIt.Api.Contracts;

namespace ToxiCode.BuyIt.Api.Kafka;

[UsedImplicitly]
public class KafkaMessageDeserializer : IDeserializer<OrderStatusChangedNotificationMessage>
{
    private readonly ILogger<KafkaMessageDeserializer> _logger;

    public KafkaMessageDeserializer(ILogger<KafkaMessageDeserializer> logger)
        => _logger = logger;

    public OrderStatusChangedNotificationMessage Deserialize(byte[]? data, SerializationContext context)
    {
        var jsonString = Encoding.Default.GetString(data!);
        _logger.LogInformation("Message was consumed from kafka. Starting deserialization");
        try
        {
            return JsonConvert.DeserializeObject<OrderStatusChangedNotificationMessage>(jsonString) ?? throw new Exception();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception occured during deserialization with message: {@Message}", ex.Message);
            return new OrderStatusChangedNotificationMessage();
        }
    }
    
}
