using ToxiCode.BuyIt.Api.Infrastructure;
using ToxiCode.BuyIt.Api.TelegramLayer.Dtos;

namespace ToxiCode.BuyIt.Api.TelegramLayer.Handlers;

public class TelegramChosenInlineResultHandler : IHandler<HandleChosenInlineResultRequest>
{
    public Task HandleAsync(HandleChosenInlineResultRequest request, CancellationToken cancellationToken) 
        => throw new NotImplementedException();
}