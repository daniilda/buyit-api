using Telegram.Bot;
using Telegram.Bot.Types;

namespace ToxiCode.BuyIt.Api.TelegramLayer.Dtos;

public record HandleChosenInlineResultRequest(ITelegramBotClient BotClient, ChosenInlineResult ChosenInlineResult);