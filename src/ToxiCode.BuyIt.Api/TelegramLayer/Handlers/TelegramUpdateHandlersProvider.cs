using ToxiCode.BuyIt.Api.Infrastructure;
using ToxiCode.BuyIt.Api.TelegramLayer.Dtos;

namespace ToxiCode.BuyIt.Api.TelegramLayer.Handlers;

public class TelegramUpdateHandlersProvider
{
    public TelegramUpdateHandlersProvider(
        IHandler<HandleCallbackQueryRequest> telegramCallbackQueryHandler, 
        IHandler<HandleMessageRequest> telegramMessageHandler,
        IHandler<HandleInlineQueryRequest> telegramInlineQueryHandler,
        IHandler<HandleChosenInlineResultRequest> telegramChosenInlineResultHandler)
    {
        TelegramCallbackQueryHandler = telegramCallbackQueryHandler;
        TelegramMessageHandler = telegramMessageHandler;
        TelegramInlineQueryHandler = telegramInlineQueryHandler;
        TelegramChosenInlineResultHandler = telegramChosenInlineResultHandler;
    }
    
    public IHandler<HandleCallbackQueryRequest> TelegramCallbackQueryHandler { get; }
    public IHandler<HandleMessageRequest> TelegramMessageHandler { get; }
    public IHandler<HandleInlineQueryRequest> TelegramInlineQueryHandler { get; }
    public IHandler<HandleChosenInlineResultRequest> TelegramChosenInlineResultHandler { get; }
}