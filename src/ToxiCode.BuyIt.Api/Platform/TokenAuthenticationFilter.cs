using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ToxiCode.BuyIt.Api.Platform;

public class TokenAuthenticationFilter : Attribute, IAsyncAuthorizationFilter
{
    private IAuthenticationManager? _tokenManager;

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        _tokenManager ??= context.HttpContext.RequestServices.GetService<IAuthenticationManager>();

        var result = context.HttpContext.Request.Headers.ContainsKey("Authorization");
        var token = string.Empty;

        if (result)
        {
            token = context.HttpContext.Request.Headers.First(x => x.Key == "Authorization").Value;
            var verificationResult = await _tokenManager!.VerifyAsync(context.HttpContext);
            if (verificationResult is not null)
            {
                context.HttpContext.Items.Add("UserId",verificationResult.User.Id); 
                context.HttpContext.Items.Add("Username", verificationResult.User.Username);
                context.HttpContext.Items.Add("Role", verificationResult.User.Role);
                return;
            }
        }
        context.ModelState.AddModelError("Unauthorized", "You are not allowed");
        context.Result = new UnauthorizedObjectResult(context.ModelState);
    }
}