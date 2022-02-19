using Telegram.Bot.Types;
using ToxiCode.BuyIt.Api.TelegramLayer.TelegramCommands;
using ToxiCode.BuyIt.Api.TelegramLayer.TelegramCommands.Abstractions;
using static ToxiCode.BuyIt.Api.TelegramLayer.TelegramCommands.Abstractions.TelegramCommand;

namespace ToxiCode.BuyIt.Api.TelegramLayer;

public class CommandAndActionsKeeper
{
    private readonly List<TelegramCommand> _commands;

    public CommandAndActionsKeeper()
        => _commands = new List<TelegramCommand>
        {
            new StartCommand()
        };

    public TelegramCommand.ExecuteCommandDelegate? GetCommand(Message message)
        => _commands
            .FirstOrDefault(x => x.Contains(message)) is not null
            ? _commands
                .First(x => x.Contains(message))
                .Execute
            : null;
}