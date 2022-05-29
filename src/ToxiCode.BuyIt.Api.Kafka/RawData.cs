using Confluent.Kafka;

namespace ToxiCode.BuyIt.Api.Kafka;

public struct RawData
{
    public byte[]? Data { get; init; }
    public SerializationContext Context { get; init; }
}