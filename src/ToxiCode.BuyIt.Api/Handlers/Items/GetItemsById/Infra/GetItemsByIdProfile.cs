using AutoMapper;
using JetBrains.Annotations;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Items.Cmds.GetItemsById;
using ToxiCode.BuyIt.Api.Handlers.Items.GetItemsById.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Items.GetItemsById.Infra;

[UsedImplicitly]
public class GetItemsByIdProfile : Profile
{
    public GetItemsByIdProfile()
    {
        CreateMap<GetItemsByIdCommand, GetItemsByIdCmd>();
    }
}