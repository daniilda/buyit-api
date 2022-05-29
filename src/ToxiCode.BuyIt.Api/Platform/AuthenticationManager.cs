using System.Net;
using System.Net.Http.Headers;
using Google.Api;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using ToxiCode.SSO.Api.Client;

namespace ToxiCode.BuyIt.Api.Platform;

public class AuthenticationManager : IAuthenticationManager
{
    private readonly HttpClient _client;

    public AuthenticationManager(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient();
    }

    public Task<AuthenticateResponse?> RefreshAsync(HttpContext context) 
        => throw new NotImplementedException();

    public async Task<AuthenticateResponse?> VerifyAsync(HttpContext context)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, "https://api.sso.txcd.xyz/v1/Auth/verify")
        {
            Headers =
            {
                {"Authorization", context.Request.Headers.Authorization.ToString()}
            }
        };
        if (context.Request.Headers.Cookie.Count > 0)
        {
            request.Headers.TryAddWithoutValidation("Cookie", context.Request.Headers.Cookie.ToArray());
        }

        var response = await _client.SendAsync(request);
        if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.ServiceUnavailable)
            return null;
        var contentString = await response.Content.ReadAsStringAsync();
        var authResponse = JsonConvert.DeserializeObject<AuthenticateResponse>(contentString);
        return authResponse;
    }
}