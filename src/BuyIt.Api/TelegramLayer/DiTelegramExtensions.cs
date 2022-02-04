using BuyIt.Api.Infrastructure;
using BuyIt.Api.Infrastructure.Options;
using BuyIt.Api.TelegramLayer.Dtos;
using BuyIt.Api.TelegramLayer.Handlers;
using BuyIt.Api.TelegramLayer.Processors;
using BuyIt.Api.TelegramLayer.Resolvers;
using Microsoft.Extensions.Options;
using Telegram.Bot;

namespace BuyIt.Api.TelegramLayer;

public static class DiServicesExtensions
{
    public static IServiceCollection AddTelegramBot(this IServiceCollection services)
    {
        var provider = services.BuildServiceProvider();
        var options = provider.GetService<IOptions<TelegramOptions>>();

        var botInstance = new TelegramBotClient(options?.Value.Token!);
        services.AddSingleton<ITelegramBotClient>(botInstance);

        switch (options?.Value.UpdateMode)
        {
            case TelegramUpdateMode.LongPooling:
                services.AddHostedService<TelegramLongPollingHostedConfigurator>();
                break;
            case TelegramUpdateMode.Webhook:
                services.AddHostedService<TelegramWebhookHostedConfigurator>();
                break;
        }
        
        services
            .AddSingleton<TelegramUpdateHandlersProvider>();

        services
            .AddSingleton<ITelegramUpdateHandler, TelegramUpdatesHandler>()
            .AddSingleton<IUpdatesResolver, TelegramUpdatesResolver>()
            .AddSingleton<CommandAndActionsKeeper>()
            .AddTransient<IHandler<HandleMessageRequest>, TelegramMessageHandler>()
            .AddTransient<IHandler<HandleCallbackQueryRequest>, TelegramCallbackQueryHandler>()
            .AddTransient<IHandler<HandleInlineQueryRequest>, TelegramInlineQueryHandler>()
            .AddTransient<IHandler<HandleChosenInlineResultRequest>, TelegramChosenInlineResultHandler>();

        return services;
    }
}