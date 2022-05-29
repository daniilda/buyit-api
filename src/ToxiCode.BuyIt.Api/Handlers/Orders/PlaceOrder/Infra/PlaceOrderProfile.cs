using AutoMapper;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Orders.Cmds.InsertOrder;
using ToxiCode.BuyIt.Api.Dtos;
using ToxiCode.BuyIt.Api.Handlers.Orders.PlaceOrder.Dtos;
using ToxiCode.BuyIt.Logistics.Api.Grpc;

namespace ToxiCode.BuyIt.Api.Handlers.Orders.PlaceOrder.Infra;

public class PlaceOrderProfile : Profile
{
    public PlaceOrderProfile()
    {
        CreateMap<PlaceOrderCommand, AddOrderRequest>()
            .ForMember(dst => dst.Items, opt => opt.MapFrom(src => src.ItemsInOrder))
            .ForMember(dst => dst.ToAddressId, opt => opt.MapFrom(src => 345678))
            .ForMember(dst => dst.FromAddressId, opt => opt.MapFrom(src => 876543));

        CreateMap<ItemInOrder, ItemAmountPair>()
            .ForMember(dst => dst.ItemId, opt => opt.MapFrom(src => src.ItemId))
            .ForMember(dst => dst.Count, opt => opt.MapFrom(src => src.Amount));
    }
}