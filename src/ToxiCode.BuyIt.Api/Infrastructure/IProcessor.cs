namespace ToxiCode.BuyIt.Api.Infrastructure;

public interface IProcessor
{
    Task StartProcessing(CancellationToken cancellationToken);
}