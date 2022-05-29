using MediatR;
using ToxiCode.BuyIt.Api.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Reviews.AddReviewByItemId.Dtos;

public record AddReviewByItemIdCommand() : IRequest
{
    public long ItemId { get; set; }

    public byte Rating { get; set; }
    
    public string? ReviewTextCons { get; set; }
    
    public string? ReviewTextPros { get; set; }
    
    public string? Commentary { get; set; }
}