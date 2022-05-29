namespace ToxiCode.BuyIt.Api.Storage;

public class UploadStreamMessageCmd
{
    public string FileName { get; init; } = null!;
    public Stream Stream { get; set; } = null!;
    public Guid FileId { get; set; }
}
