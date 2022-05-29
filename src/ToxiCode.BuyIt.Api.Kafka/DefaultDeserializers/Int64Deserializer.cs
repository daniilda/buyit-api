using Confluent.Kafka;

namespace ToxiCode.BuyIt.Api.Kafka.DefaultDeserializers
{
    public class Int64Deserializer : IDeserializer<long>
    {
        private readonly Confluent.Kafka.IDeserializer<long> _confluentDeserializer;

        public Int64Deserializer()
            => _confluentDeserializer = Deserializers.Int64;

        public virtual long Deserialize(byte[]? data, SerializationContext context)
            => _confluentDeserializer.Deserialize(data, data is null, context);
    }
}