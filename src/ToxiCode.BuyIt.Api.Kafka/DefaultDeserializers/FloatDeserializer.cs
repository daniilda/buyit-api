
using Confluent.Kafka;

namespace ToxiCode.BuyIt.Api.Kafka.DefaultDeserializers;

public class FloatDeserializer: IDeserializer<float>
{
    private readonly Confluent.Kafka.IDeserializer<float> _confluentDeserializer;

    public FloatDeserializer()
        => _confluentDeserializer = Deserializers.Single;

    public virtual float Deserialize(byte[]? data, SerializationContext context)
        => _confluentDeserializer.Deserialize(data, data is null, context);
}