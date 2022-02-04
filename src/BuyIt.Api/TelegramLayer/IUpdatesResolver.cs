using Telegram.Bot;
using Telegram.Bot.Types;

namespace BuyIt.Api.TelegramLayer;

public interface IUpdatesResolver
{
    Task ResolveUpdate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken);
}