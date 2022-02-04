using BuyIt.Api.TelegramLayer.TelegramCommands;
using BuyIt.Api.TelegramLayer.TelegramCommands.Abstractions;
using Telegram.Bot.Types;
using static BuyIt.Api.TelegramLayer.TelegramCommands.Abstractions.TelegramCommand;

namespace BuyIt.Api.TelegramLayer;

public class CommandAndActionsKeeper
{
    private readonly List<TelegramCommand> _commands;

    public CommandAndActionsKeeper()
        => _commands = new List<TelegramCommand>
        {
            new StartCommand()
        };

    public ExecuteCommandDelegate? GetCommand(Message message)
        => _commands
            .FirstOrDefault(x => x.Contains(message)) is not null
            ? _commands
                .First(x => x.Contains(message))
                .Execute
            : null;
}