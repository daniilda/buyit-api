namespace ToxiCode.BuyIt.Api.Contracts;

public class Image
{
    public string FileName { get; set; } = null!;
    
    public string? Description { get; set; }

    public string Url { get; set; } = null!;
}