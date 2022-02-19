using ToxiCode.BuyIt.Api.Infrastructure;
using ToxiCode.BuyIt.Api.TelegramLayer.Dtos;

namespace ToxiCode.BuyIt.Api.TelegramLayer.Handlers;

public class TelegramInlineQueryHandler : IHandler<HandleInlineQueryRequest>
{
    public Task HandleAsync(HandleInlineQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}