namespace ToxiCode.BuyIt.Api.Kafka;

public class DeserializerProvider<TKey, TValue>
{
    public DeserializerProvider(IDeserializer<TKey> keyDeserializer, IDeserializer<TValue> valueDeserializer)
    {
        KeyDeserializer = keyDeserializer;
        ValueDeserializer = valueDeserializer;
    }

    public IDeserializer<TKey> KeyDeserializer { get; }

    public IDeserializer<TValue> ValueDeserializer { get; }
}

public class DeserializerProvider<TValue>
{
    public DeserializerProvider(IDeserializer<TValue> valueDeserializer)
        => ValueDeserializer = valueDeserializer;

    public IDeserializer<TValue> ValueDeserializer { get; }
}