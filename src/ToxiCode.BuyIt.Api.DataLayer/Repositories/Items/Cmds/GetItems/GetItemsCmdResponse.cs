using ToxiCode.BuyIt.Api.Dtos;
using ToxiCode.BuyIt.Api.Dtos.Pagination;

namespace ToxiCode.BuyIt.Api.DataLayer.Repositories.Items.Cmds.GetItems;

public class GetItemsCmdResponse
{
    public GetItemsCmdResponse(Item[] items, PaginationResponse? paginationResponse)
    {
        Items = items;
        Pagination = paginationResponse;
    }

    public GetItemsCmdResponse()
    {
    }
    
    public Item[] Items { get; init; } = Array.Empty<Item>();
    
    public PaginationResponse? Pagination { get; init; }
}