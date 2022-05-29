namespace ToxiCode.BuyIt.Api.Storage;

public class UploadFileResponse
{
    public UploadFileResponse(string url, string originalFileName, Guid fileId)
    {
        Url = url;
        OriginalFileName = originalFileName;
        FileId = fileId;
    } 
    public string Url { get; init; }
    
    public string OriginalFileName { get; init; }
    
    public Guid FileId { get; init; }
}
