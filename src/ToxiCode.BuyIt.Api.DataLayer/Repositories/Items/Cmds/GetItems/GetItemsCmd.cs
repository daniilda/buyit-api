using ToxiCode.BuyIt.Api.Dtos;
using ToxiCode.BuyIt.Api.Dtos.Enums;
using ToxiCode.BuyIt.Api.Dtos.Pagination;

namespace ToxiCode.BuyIt.Api.DataLayer.Repositories.Items.Cmds.GetItems;

public class GetItemsCmd
{
    public Filter? Filter { get; init; }

    public Sorting Sorting { get; init; } = new() {Mode = SortingMode.None, Type = SortingType.None};

    public Pagination Pagination { get; init; } = new() {Count = 100, Offset = 0};
}