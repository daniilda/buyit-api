using Telegram.Bot;
using Telegram.Bot.Types;

namespace ToxiCode.BuyIt.Api.TelegramLayer.Dtos;

public record HandleMessageRequest(ITelegramBotClient BotClient, Message Message);