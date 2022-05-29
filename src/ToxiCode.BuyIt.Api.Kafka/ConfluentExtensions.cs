using Confluent.Kafka;

namespace ToxiCode.BuyIt.Api.Kafka;

internal static class ConfluentExtensions
{
    private static void Commit<TKey, TValue>(this IConsumer<TKey, TValue> consumer,
        params ConsumeResult<TKey, TValue>[] values)
    {
        consumer.Commit(values.Select(_ => new TopicPartitionOffset(_.TopicPartition, _.Offset + 1)));
    }

    private static void Store<TKey, TValue>(this IConsumer<TKey, TValue> consumer,
        params ConsumeResult<TKey, TValue>[] values)
    {
        foreach (var consumeResult in values)
            consumer.StoreOffset(consumeResult);
    }

    public static void SendOffsets<TKey, TValue>(this IConsumer<TKey, TValue> consumer, CommitType commitType,
        params ConsumeResult<TKey, TValue>[] values)
    {
        if (commitType == CommitType.Immediate)
            consumer.Commit(values);
        else
            consumer.Store(values);
    }

    public static T Deserialize<T>(this Confluent.Kafka.IDeserializer<T> deserializer,
        ReadOnlySpan<byte> data, SerializationContext context)
        => deserializer.Deserialize(data, data == null || data.IsEmpty, context);
}