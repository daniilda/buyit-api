using AutoMapper;
using JetBrains.Annotations;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Items.Cmds.InsertItems;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Pictures.Cmds.InsertPicturesForItems;
using ToxiCode.BuyIt.Api.Handlers.Items.AddItem.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Items.AddItem.Infra;

[UsedImplicitly]
public class AddItemProfile : Profile
{
    public AddItemProfile()
    {
        CreateMap<AddItemCommand, InsertItemsCmd>()
            .ForMember(dst => dst.Items, opt => opt.MapFrom(src => new[] {src.Item}));

        CreateMap<AddItemCommand, InsertPicturesForItemCmd>()
            .ForMember(dst => dst.Pictures, opt => opt.MapFrom(src => src.Item.Pictures));
    }
}