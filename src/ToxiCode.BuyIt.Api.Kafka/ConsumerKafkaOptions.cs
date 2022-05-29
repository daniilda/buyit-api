using JetBrains.Annotations;

namespace ToxiCode.BuyIt.Api.Kafka;

[UsedImplicitly(ImplicitUseTargetFlags.Members)]
public class ConsumerKafkaOptions
{
    public string TopicName { get; set; } = null!;

    public string GroupId { get; set; } = null!;

    public string BootstrapServers { get; set; } = null!;
}