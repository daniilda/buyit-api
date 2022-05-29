using Confluent.Kafka;
using ToxiCode.BuyIt.Api.Contracts;
using ToxiCode.BuyIt.Api.Kafka.DefaultDeserializers;

namespace ToxiCode.BuyIt.Api.Kafka;

public static class KafkaExtensions
{
    public static IServiceCollection AddKafka(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHostedService<KafkaConsumerHostedService<Ignore, OrderStatusChangedNotificationMessage, IConsumeHandler<Ignore, OrderStatusChangedNotificationMessage>>>();
        services.AddSingleton<IConsumeHandler<Ignore, OrderStatusChangedNotificationMessage>, MainKafkaHandler>();
        services.AddSingleton<IDeserializer<OrderStatusChangedNotificationMessage>, KafkaMessageDeserializer>();
        services.AddSingleton<IDeserializer<Ignore>, IgnoreDeserializer>();
        services.AddSingleton<DeserializerProvider<Ignore, OrderStatusChangedNotificationMessage>>();
        services.AddOptions<ConsumerKafkaOptions>()
            .Bind(configuration.GetSection(nameof(ConsumerKafkaOptions)));
        return services;
    }

}