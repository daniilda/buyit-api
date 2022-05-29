using System.Net;

namespace ToxiCode.BuyIt.Api.Platform.Middlewares;

public class SwaggerUrlPortAuthMiddleware {
    private readonly RequestDelegate _next;

    public SwaggerUrlPortAuthMiddleware(RequestDelegate next) 
        => _next = next;

    public async Task InvokeAsync(HttpContext context, IConfiguration configuration) {
        if (context.Request.Path.StartsWithSegments("/swagger")
            && !TCPlatformEnvironment.DebugPort.Equals(context.Request.Host.Port)
            && TCPlatformEnvironment.IsProduction 
            && TCPlatformEnvironment.IsRunningInContainer) {
            context.Response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
        }
        else {
            await _next.Invoke(context);
        }
    }
}