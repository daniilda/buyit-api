using ToxiCode.BuyIt.Api.Dtos;

namespace ToxiCode.BuyIt.Api.DataLayer.Repositories.Reviews.Cmds.InsertReviewByItemId;

public record InsertReviewByItemIdCmd()
{
    public long ItemId { get; set; }
    
    public Guid UserId { get; set; }
    
    public byte Rating { get; set; }
    
    public string? ReviewTextCons { get; set; }
    
    public string? ReviewTextPros { get; set; }
    
    public string? Commentary { get; set; }
};