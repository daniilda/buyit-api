using Telegram.Bot;
using Telegram.Bot.Types;

namespace ToxiCode.BuyIt.Api.TelegramLayer;

public interface ITelegramUpdateHandler
{
    Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken);

    Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken);
}