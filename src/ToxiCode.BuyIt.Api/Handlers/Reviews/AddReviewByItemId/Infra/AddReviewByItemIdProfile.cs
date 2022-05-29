using AutoMapper;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Reviews.Cmds.InsertReviewByItemId;
using ToxiCode.BuyIt.Api.Handlers.Reviews.AddReviewByItemId.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Reviews.AddReviewByItemId.Infra;

public class AddReviewByItemIdProfile : Profile
{
    public AddReviewByItemIdProfile()
    {
        CreateMap<AddReviewByItemIdCommand, InsertReviewByItemIdCmd>();
    }
}