using Microsoft.AspNetCore.Http;

namespace ToxiCode.BuyIt.Api.Common;

public class HttpCancellationTokenAccessor
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpCancellationTokenAccessor(IHttpContextAccessor httpContextAccessor)
        => _httpContextAccessor = httpContextAccessor;

    public CancellationToken Token
        => _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
}