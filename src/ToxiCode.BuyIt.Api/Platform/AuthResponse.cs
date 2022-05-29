using System.Text.Json.Serialization;
using ToxiCode.SSO.Api.Client;

namespace ToxiCode.BuyIt.Api.Platform;

public class AuthResponse
{
    [JsonPropertyName("user")]
    public User User { get; set; } = null!;
    
    [JsonPropertyName("jwtToken")]
    public string JwtToken { get; set; } = null!;
    
    [JsonPropertyName("refreshToken")]
    public string RefreshToken { get; set; } = null!;
}