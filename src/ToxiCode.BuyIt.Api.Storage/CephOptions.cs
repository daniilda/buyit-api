using System.ComponentModel.DataAnnotations;

namespace ToxiCode.BuyIt.Api.Storage;

public class CephOptions
{
    public string? BucketName { get; set; }
    
    public string? AccessKey { get; set; }
    
    public string? SecretKey { get; set; }
    
    public string? EndPoint { get; set; }
    
    public string? Path { get; set; }
}
