using Telegram.Bot.Types.Enums;
using ToxiCode.BuyIt.Api.Infrastructure.Options;
using static ToxiCode.BuyIt.Api.EnvironmentConstants;

namespace ToxiCode.BuyIt.Api.Infrastructure.Extensions;

public static class EnvironmentOptionsExtensions
{
    public static IServiceCollection TryAddAllOptions(this IServiceCollection services, IConfiguration configuration)
        => services.TryAddTelegramEnvironmentOptions(configuration);

    private static IServiceCollection TryAddTelegramEnvironmentOptions(this IServiceCollection services,
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