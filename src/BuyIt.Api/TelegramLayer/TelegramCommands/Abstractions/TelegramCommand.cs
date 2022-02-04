using BuyIt.Api.DataLayer;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BuyIt.Api.TelegramLayer.TelegramCommands.Abstractions;

public abstract class TelegramCommand
{
    public delegate Task ExecuteCommandDelegate(
        Message message, 
        ITelegramBotClient telegramBotClient,
        IRepository repository,
        CancellationToken cancellationToken);
    
    public abstract string Name { get; }

    public abstract Task Execute(
        Message message, 
        ITelegramBotClient telegramBotClient, 
        IRepository repository, 
        CancellationToken cancellationToken);

    public abstract bool Contains(Message message);
}