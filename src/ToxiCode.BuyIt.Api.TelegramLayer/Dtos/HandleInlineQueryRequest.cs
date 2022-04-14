using Telegram.Bot;
using Telegram.Bot.Types;

namespace ToxiCode.BuyIt.Api.TelegramLayer.Dtos;

public record HandleInlineQueryRequest(ITelegramBotClient BotClient, InlineQuery InlineQuery);