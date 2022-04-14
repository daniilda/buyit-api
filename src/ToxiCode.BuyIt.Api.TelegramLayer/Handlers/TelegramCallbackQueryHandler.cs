using ToxiCode.BuyIt.Api.TelegramLayer.Dtos;

namespace ToxiCode.BuyIt.Api.TelegramLayer.Handlers;

public class TelegramCallbackQueryHandler : IHandler<HandleCallbackQueryRequest>
{
    public Task HandleAsync(HandleCallbackQueryRequest request, CancellationToken cancellationToken) 
        => throw new NotImplementedException();
}