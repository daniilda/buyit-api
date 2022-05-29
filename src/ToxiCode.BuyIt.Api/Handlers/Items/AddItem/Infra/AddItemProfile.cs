using AutoMapper;
using JetBrains.Annotations;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Images.Cmds.InsertPicturesForItems;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Items.Cmds.InsertItems;
using ToxiCode.BuyIt.Api.Handlers.Items.AddItem.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Items.AddItem.Infra;

[UsedImplicitly]
public class AddItemProfile : Profile
{
    public AddItemProfile()
    {
        CreateMap<AddItemCommand, ItemToAdd>();

        CreateMap<ItemToAdd, InsertPicturesForItemCmd>()
            .ForMember(dst => dst.ImagesIds, opt => opt.MapFrom(src => src.Images))
            .ForMember(dst => dst.ItemId, opt => opt.MapFrom(src => src.Id));

        CreateMap<AddItemCommand, Logistics.Api.Grpc.AddItem>()
            .ForMember(dst => dst.Count, opt => opt.MapFrom(src => src.InStockAmount))
            .ForMember(dst => dst.Height, opt => opt.MapFrom(src => src.Height))
            .ForMember(dst => dst.Length, opt => opt.MapFrom(src => src.Length))
            .ForMember(dst => dst.Weight, opt => opt.MapFrom(src => src.Weight))
            .ForMember(dst => dst.Width, opt => opt.MapFrom(src => src.Width));
    }
}