using Telegram.Bot;
using Telegram.Bot.Types;
using ILogger = Serilog.ILogger;

namespace BuyIt.Api.TelegramLayer.Handlers;

public class TelegramUpdatesHandler : ITelegramUpdateHandler
{
    private readonly IUpdatesResolver _resolver;
    private readonly ILogger _logger;

    public TelegramUpdatesHandler(
        IUpdatesResolver resolver,
        ILogger logger)
    {
        _resolver = resolver;
        _logger = logger;
    }

    public Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        _logger.Information("Update was received: {@Update}", update);
        _resolver.ResolveUpdate(botClient, update, cancellationToken);   
        _logger.Information("Update handled");
        return Task.CompletedTask;
    }
    
    public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        _logger.Error(exception, "Error has occured while pooling");
        return Task.CompletedTask;
    }
}