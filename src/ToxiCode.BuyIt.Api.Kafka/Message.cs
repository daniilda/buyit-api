using Confluent.Kafka;
using JetBrains.Annotations;

namespace ToxiCode.BuyIt.Api.Kafka;

public class Message<TValue>
{
    public TValue Value { get; init; } = default!;
    public DateTime TimeStamp { get; init; }
    public Headers Headers { get; init; } = null!;
    public string Topic { get; init; } = null!;
    public string GroupId { [UsedImplicitly] get; init; } = null!;
    public int Partition { get; init; }
    public long Offset { get; init; }
}

public class Message<TKey, TValue> : Message<TValue>
{
    public TKey Key { get; init; } = default!;
}
