using Confluent.Kafka;

namespace ToxiCode.BuyIt.Api.Kafka;

internal class RawDataDeserializer: Confluent.Kafka.IDeserializer<RawData>
{
    public RawData Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        => new()
        {
            Data = isNull
                ? null
                : data.ToArray(),
            Context = context
        };
}
