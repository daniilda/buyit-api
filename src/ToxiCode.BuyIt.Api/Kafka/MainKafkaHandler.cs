using Confluent.Kafka;
using ToxiCode.BuyIt.Api.Contracts;

namespace ToxiCode.BuyIt.Api.Kafka;

public class MainKafkaHandler : IConsumeHandler<Ignore, OrderStatusChangedNotificationMessage>
{
    private readonly ILogger<MainKafkaHandler> _logger;
    
    public MainKafkaHandler(ILogger<MainKafkaHandler> logger)
        => _logger = logger;

    public Task HandleAsync(Message<Ignore, OrderStatusChangedNotificationMessage> message, CancellationToken ctx)
    {
        _logger.LogInformation("Message for notification: {@Message}", message);
        return Task.CompletedTask;
    }
}