using Telegram.Bot;
using Telegram.Bot.Types;

namespace BuyIt.Api.TelegramLayer.Dtos;

public record HandleCallbackQueryRequest(ITelegramBotClient BotClient, CallbackQuery CallbackQuery);