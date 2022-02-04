using Telegram.Bot;
using Telegram.Bot.Types;

namespace BuyIt.Api.TelegramLayer.Dtos;

public record HandleChosenInlineResultRequest(ITelegramBotClient BotClient, ChosenInlineResult ChosenInlineResult);