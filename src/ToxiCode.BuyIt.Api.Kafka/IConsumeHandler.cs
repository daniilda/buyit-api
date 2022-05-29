namespace ToxiCode.BuyIt.Api.Kafka;

public interface IConsumeHandler<TKey, TValue> where TKey : class where TValue : class
{
    Task HandleAsync(Message<TKey,TValue> message, CancellationToken ctx);
}

public interface IConsumeHandler<TValue> where TValue : class
{
    Task HandleAsync(Message<TValue> message, CancellationToken ctx);
}