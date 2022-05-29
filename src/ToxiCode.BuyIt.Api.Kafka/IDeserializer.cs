using Confluent.Kafka;

namespace ToxiCode.BuyIt.Api.Kafka;

public interface IDeserializer<out T>
{
    T Deserialize(byte[]? data, SerializationContext context);
}
