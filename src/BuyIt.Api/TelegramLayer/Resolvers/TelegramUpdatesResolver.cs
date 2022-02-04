using BuyIt.Api.TelegramLayer.Dtos;
using BuyIt.Api.TelegramLayer.Handlers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BuyIt.Api.TelegramLayer.Resolvers;

public class TelegramUpdatesResolver : IUpdatesResolver
{
    private readonly TelegramUpdateHandlersProvider _provider;

    public TelegramUpdatesResolver(TelegramUpdateHandlersProvider provider)
        => _provider = provider;

    public Task ResolveUpdate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        => update.Type switch
        {
            UpdateType.Message => _provider.TelegramMessageHandler.HandleAsync(
                new HandleMessageRequest(botClient, update.Message!), cancellationToken),
            UpdateType.EditedMessage => _provider.TelegramMessageHandler.HandleAsync(
                new HandleMessageRequest(botClient, update.Message!), cancellationToken),
            UpdateType.InlineQuery => _provider.TelegramInlineQueryHandler.HandleAsync(
                new HandleInlineQueryRequest(botClient, update.InlineQuery!), cancellationToken),
            UpdateType.ChosenInlineResult => _provider.TelegramChosenInlineResultHandler.HandleAsync(
                new HandleChosenInlineResultRequest(botClient, update.ChosenInlineResult!), cancellationToken),
            UpdateType.CallbackQuery => _provider.TelegramCallbackQueryHandler.HandleAsync(
                new HandleCallbackQueryRequest(botClient, update.CallbackQuery!), cancellationToken),
            _ => throw new NotImplementedException()
        };
}