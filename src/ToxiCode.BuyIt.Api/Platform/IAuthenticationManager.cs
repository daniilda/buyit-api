using Microsoft.AspNetCore.Authorization;
using ToxiCode.SSO.Api.Client;

namespace ToxiCode.BuyIt.Api.Platform;

public interface IAuthenticationManager
{
    public Task<AuthenticateResponse?> RefreshAsync(HttpContext context);

    public Task<AuthenticateResponse?> VerifyAsync(HttpContext context);
}