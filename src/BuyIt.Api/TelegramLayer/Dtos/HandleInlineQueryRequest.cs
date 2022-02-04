using Telegram.Bot;
using Telegram.Bot.Types;

namespace BuyIt.Api.TelegramLayer.Dtos;

public record HandleInlineQueryRequest(ITelegramBotClient BotClient, InlineQuery InlineQuery);