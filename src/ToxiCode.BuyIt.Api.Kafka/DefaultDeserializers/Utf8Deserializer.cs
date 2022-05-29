using Confluent.Kafka;

namespace ToxiCode.BuyIt.Api.Kafka.DefaultDeserializers;

public class Utf8Deserializer: IDeserializer<string>
{
    private readonly Confluent.Kafka.IDeserializer<string> _confluentDeserializer;

    public Utf8Deserializer()
        => _confluentDeserializer = Deserializers.Utf8;

    public virtual string Deserialize(byte[]? data, SerializationContext context)
        => _confluentDeserializer.Deserialize(data,data is null, context);
}