using BuyIt.Api.Infrastructure;
using BuyIt.Api.TelegramLayer.Dtos;

namespace BuyIt.Api.TelegramLayer.Handlers;

public class TelegramChosenInlineResultHandler : IHandler<HandleChosenInlineResultRequest>
{
    public Task HandleAsync(HandleChosenInlineResultRequest request, CancellationToken cancellationToken) 
        => throw new NotImplementedException();
}