namespace ToxiCode.BuyIt.Api.Dtos;

public class Property<T>
{
    public string Name { get; set; } = null!;

    public T Value { get; set; } = default!;
}