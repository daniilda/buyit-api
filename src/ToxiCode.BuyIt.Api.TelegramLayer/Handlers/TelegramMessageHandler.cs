using ToxiCode.BuyIt.Api.DataLayer.Repositories;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Telegram;
using ToxiCode.BuyIt.Api.TelegramLayer.Dtos;

namespace ToxiCode.BuyIt.Api.TelegramLayer.Handlers;

public class TelegramMessageHandler : IHandler<HandleMessageRequest>
{
    private readonly CommandAndActionsKeeper _keeper;
    private readonly TelegramRepository _repository;

    public TelegramMessageHandler(CommandAndActionsKeeper keeper, TelegramRepository repository)
    {
        _keeper = keeper;
        _repository = repository;
    }

    public Task HandleAsync(HandleMessageRequest request, CancellationToken cancellationToken)
    {
        var commandToExecute = _keeper.GetCommand(request.Message);
        return commandToExecute is not null 
            ? commandToExecute(request.Message, request.BotClient, _repository, cancellationToken) 
            : Task.CompletedTask;
    }
}