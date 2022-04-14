using MediatR;
using ToxiCode.BuyIt.Api.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Items.UpdateItem.Dtos;

public record UpdateItemCommand(Item Item) : IRequest;