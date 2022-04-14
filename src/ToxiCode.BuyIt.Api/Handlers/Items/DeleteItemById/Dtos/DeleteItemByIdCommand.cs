using MediatR;

namespace ToxiCode.BuyIt.Api.Handlers.Items.DeleteItemById.Dtos;

public record DeleteItemByIdCommand(long Id) : IRequest;