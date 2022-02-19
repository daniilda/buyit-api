using ToxiCode.BuyIt.Api.HttpControllers;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using ToxiCode.BuyIt.Api.HttpControllers.Webhooks;
using ToxiCode.BuyIt.Api.Infrastructure.Options;

namespace ToxiCode.BuyIt.Api.TelegramLayer.Processors;

public class TelegramWebhookHostedConfigurator : IHostedService
{
    private readonly ITelegramBotClient _telegramBotClient;
    private readonly IOptions<TelegramOptions> _options;

    public TelegramWebhookHostedConfigurator(ITelegramBotClient telegramBotClient, IOptions<TelegramOptions> options)
    {
        _telegramBotClient = telegramBotClient;
        _options = options;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var webhookAddress = @$"{_options.Value.HostUrl}{WebhooksRoutes.TelegramWebhookRoute}{_options.Value.Token}";
        var allowedUpdates = _options.Value.AllowedUpdates;
        await _telegramBotClient.SetWebhookAsync(
            webhookAddress,
            allowedUpdates: allowedUpdates,
            cancellationToken: cancellationToken);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
        => await _telegramBotClient.DeleteWebhookAsync(cancellationToken: cancellationToken);
}