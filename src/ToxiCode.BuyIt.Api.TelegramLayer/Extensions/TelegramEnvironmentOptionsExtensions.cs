using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot.Types.Enums;
using ToxiCode.BuyIt.Api.TelegramLayer.Options;
using static ToxiCode.BuyIt.Api.TelegramLayer.TelegramEnvironmentConstants;
using static ToxiCode.BuyIt.Api.Common.EnvironmentConstants;

namespace ToxiCode.BuyIt.Api.TelegramLayer.Extensions;

public static class TelegramEnvironmentOptionsExtensions
{
    public static IServiceCollection TryAddTelegramEnvironmentOptions(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<TelegramOptions>(x =>
        {
            x.Token = configuration[TelegramBotToken] 
                      ?? configuration.GetValue<string>(nameof(TelegramOptions) + ":" + nameof(TelegramOptions.Token));
            x.UpdateMode = Enum.Parse<TelegramUpdateMode>(
                               configuration[TelegramBotUpdateMode]
                ?? configuration.GetValue<string>(nameof(TelegramOptions) + ":" + nameof(TelegramOptions.UpdateMode)));
            x.HostUrl = configuration[HostUrl]
                        ?? configuration.GetValue<string>(nameof(TelegramOptions) + ":" + nameof(TelegramOptions.HostUrl));
            x.AllowedUpdates = configuration
                .GetSection(nameof(TelegramOptions) + ":" + nameof(TelegramOptions.AllowedUpdates)).Get<UpdateType[]>();
        });

        return services;
    }
}