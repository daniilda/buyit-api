using BuyIt.Api.Infrastructure;
using BuyIt.Api.TelegramLayer.Dtos;

namespace BuyIt.Api.TelegramLayer.Handlers;

public class TelegramInlineQueryHandler : IHandler<HandleInlineQueryRequest>
{
    public Task HandleAsync(HandleInlineQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}