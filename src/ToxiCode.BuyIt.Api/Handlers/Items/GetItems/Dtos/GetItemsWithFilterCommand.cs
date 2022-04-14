using MediatR;
using ToxiCode.BuyIt.Api.Dtos;
using ToxiCode.BuyIt.Api.Dtos.Pagination;

namespace ToxiCode.BuyIt.Api.Handlers.Items.GetItems.Dtos;

public record GetItemsWithFilterCommand(Filter? Filter, Pagination? Pagination, Sorting? Sorting) : IRequest<GetItemsWithFilterResponse>;