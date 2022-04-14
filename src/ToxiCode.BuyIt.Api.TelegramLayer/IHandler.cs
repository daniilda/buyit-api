namespace ToxiCode.BuyIt.Api.TelegramLayer;

public interface IHandler<TResponse, in TRequest>
{
    Task<TResponse> HandleAsync(TRequest request, CancellationToken cancellationToken);
}

public interface IHandler<in TRequest>
{
    Task HandleAsync(TRequest request, CancellationToken cancellationToken);
}