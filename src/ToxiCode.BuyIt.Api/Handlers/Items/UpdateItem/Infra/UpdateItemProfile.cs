using AutoMapper;
using JetBrains.Annotations;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Images.Cmds.UpdatePicturesForItem;
using ToxiCode.BuyIt.Api.Handlers.Items.UpdateItem.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Items.UpdateItem.Infra;

[UsedImplicitly]
public class UpdateItemProfile : Profile
{
    public UpdateItemProfile()
    {
        CreateMap<UpdateItemCommand, UpdatePicturesForItemCmd>()
            .ForMember(dst => dst.ItemId, opt => opt.MapFrom(src => src.Item.Id))
            .ForMember(dst => dst.Pictures, opt => opt.MapFrom(src => src.Item.ImageUrls));
    }
}