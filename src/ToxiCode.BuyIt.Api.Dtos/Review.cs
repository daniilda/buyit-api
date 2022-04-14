namespace ToxiCode.BuyIt.Api.Dtos;

public class Review
{
    public long Id { get; set; }
    
    public long UserId { get; set; }
    
    public byte Rating { get; set; }
    
    public string? ReviewTextCons { get; set; }
    
    public string? ReviewTextPros { get; set; }
    
    public string? Commentary { get; set; }
}