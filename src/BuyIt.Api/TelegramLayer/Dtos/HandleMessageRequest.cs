using Telegram.Bot;
using Telegram.Bot.Types;

namespace BuyIt.Api.TelegramLayer.Dtos;

public record HandleMessageRequest(ITelegramBotClient BotClient, Message Message);