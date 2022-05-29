using Confluent.Kafka;

namespace ToxiCode.BuyIt.Api.Kafka.DefaultDeserializers;

public class DoubleDeserializer: IDeserializer<double>
{
    private readonly Confluent.Kafka.IDeserializer<double> _confluentDeserializer;

    public DoubleDeserializer()
        => _confluentDeserializer = Deserializers.Double;

    public virtual double Deserialize(byte[]? data, SerializationContext context)
        => _confluentDeserializer.Deserialize(data,data is null, context);
}