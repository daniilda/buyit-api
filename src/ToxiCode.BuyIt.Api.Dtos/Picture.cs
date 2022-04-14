namespace ToxiCode.BuyIt.Api.Dtos;

public class Picture
{
    public Guid Id { get; set; }

    public string FileName { get; set; } = null!;
    
    public string? Description { get; set; }

    public string Url { get; set; } = null!;
}