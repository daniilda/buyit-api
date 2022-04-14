using MediatR;

namespace ToxiCode.BuyIt.Api.Handlers.Items.GetItemById.Dtos;

public record GetItemByIdCommand(long Id) : IRequest<GetItemByIdResponse>;