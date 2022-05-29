using Confluent.Kafka;

namespace ToxiCode.BuyIt.Api.Kafka.DefaultDeserializers;

public class IgnoreDeserializer: IDeserializer<Ignore>
{
    public Ignore Deserialize(byte[]? data, SerializationContext context) 
        => null!;
}