namespace ToxiCode.BuyIt.Api.Dtos;

public class Category
{
    public long Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string? Description { get; set; }

    public Category ParentCategory { get; set; } = null!;
}