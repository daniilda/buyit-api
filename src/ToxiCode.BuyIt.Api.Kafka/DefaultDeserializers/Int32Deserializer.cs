using Confluent.Kafka;

namespace ToxiCode.BuyIt.Api.Kafka.DefaultDeserializers;

public class Int32Deserializer : IDeserializer<int>
{
    private readonly Confluent.Kafka.IDeserializer<int> _confluentDeserializer;

    public Int32Deserializer()
        => _confluentDeserializer = Deserializers.Int32;

    public virtual int Deserialize(byte[]? data, SerializationContext context)
        => _confluentDeserializer.Deserialize(data, data is null, context);
}