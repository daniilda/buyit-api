using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using ToxiCode.BuyIt.Api.TelegramLayer.Options;

namespace ToxiCode.BuyIt.Api.TelegramLayer.Processors;

public class TelegramLongPollingHostedConfigurator : IHostedService
{
    private readonly ITelegramUpdateHandler _telegramUpdateHandler;
    private ITelegramBotClient _bot;
    private readonly TelegramOptions _options;

    public TelegramLongPollingHostedConfigurator(
        ITelegramUpdateHandler telegramUpdateHandler,
        IOptions<TelegramOptions> options,
        ITelegramBotClient bot)
    {
        _telegramUpdateHandler = telegramUpdateHandler;
        _bot = bot;
        _options = options.Value;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        var clientOptions = new ReceiverOptions
        {
            AllowedUpdates = _options.AllowedUpdates
        };

        return _bot?.ReceiveAsync(
            _telegramUpdateHandler.HandleUpdateAsync,
            _telegramUpdateHandler.HandleErrorAsync,
            clientOptions,
            cancellationToken) ?? Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}