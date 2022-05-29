using MediatR;

namespace ToxiCode.BuyIt.Api.Handlers.Orders.GetOrdersByUserId.Dtos;

public class GetOrdersByUserIdCommand : IRequest<GetOrdersByUserIdResponse>
{
    public Guid UserId { get; set; }
}