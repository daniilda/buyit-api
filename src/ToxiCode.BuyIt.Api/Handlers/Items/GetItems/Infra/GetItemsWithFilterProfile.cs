using AutoMapper;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Items.Cmds.GetItems;
using ToxiCode.BuyIt.Api.Handlers.Items.GetItems.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Items.GetItems.Infra;

public class GetItemsWithFilterProfile : Profile
{
    public GetItemsWithFilterProfile()
    {
        CreateMap<GetItemsWithFilterCommand, GetItemsCmd>()
            .ForMember(dst => dst.Pagination, opt => opt.Condition(x => x.Pagination != null))
            .ForMember(dst => dst.Sorting, opt => opt.Condition(x => x.Sorting != null));

        CreateMap<GetItemsCmdResponse, GetItemsWithFilterResponse>();
    }
}