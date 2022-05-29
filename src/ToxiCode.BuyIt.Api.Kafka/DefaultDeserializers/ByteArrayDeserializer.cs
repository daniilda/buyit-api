using Confluent.Kafka;

namespace ToxiCode.BuyIt.Api.Kafka.DefaultDeserializers;

public class ByteArrayDeserializer : IDeserializer<byte[]>
{
    private readonly Confluent.Kafka.IDeserializer<byte[]> _confluentDeserializer;

    public ByteArrayDeserializer()
        => _confluentDeserializer = Confluent.Kafka.Deserializers.ByteArray;

    public virtual byte[] Deserialize(byte[]? data, SerializationContext context)
        => _confluentDeserializer.Deserialize(data, data is null, context);
}