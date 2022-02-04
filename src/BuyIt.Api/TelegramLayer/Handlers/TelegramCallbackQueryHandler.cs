using BuyIt.Api.Infrastructure;
using BuyIt.Api.TelegramLayer.Dtos;

namespace BuyIt.Api.TelegramLayer.Handlers;

public class TelegramCallbackQueryHandler : IHandler<HandleCallbackQueryRequest>
{
    public Task HandleAsync(HandleCallbackQueryRequest request, CancellationToken cancellationToken) 
        => throw new NotImplementedException();
}