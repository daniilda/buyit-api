using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using ToxiCode.BuyIt.Api.TelegramLayer.Dtos;
using ToxiCode.BuyIt.Api.TelegramLayer.Extensions;
using ToxiCode.BuyIt.Api.TelegramLayer.Handlers;
using ToxiCode.BuyIt.Api.TelegramLayer.Options;
using ToxiCode.BuyIt.Api.TelegramLayer.Processors;
using ToxiCode.BuyIt.Api.TelegramLayer.Resolvers;

namespace ToxiCode.BuyIt.Api.TelegramLayer;

public static class DiServicesExtensions
{
    public static IServiceCollection AddTelegramBot(this IServiceCollection services, IConfiguration configuration)
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
            .AddScoped<TelegramUpdateHandlersProvider>();

        services
            .AddScoped<ITelegramUpdateHandler, TelegramUpdatesHandler>()
            .AddScoped<IUpdatesResolver, TelegramUpdatesResolver>()
            .AddScoped<CommandAndActionsKeeper>()
            .AddTransient<IHandler<HandleMessageRequest>, TelegramMessageHandler>()
            .AddTransient<IHandler<HandleCallbackQueryRequest>, TelegramCallbackQueryHandler>()
            .AddTransient<IHandler<HandleInlineQueryRequest>, TelegramInlineQueryHandler>()
            .AddTransient<IHandler<HandleChosenInlineResultRequest>, TelegramChosenInlineResultHandler>()
            .TryAddTelegramEnvironmentOptions(configuration);

        return services;
    }
}