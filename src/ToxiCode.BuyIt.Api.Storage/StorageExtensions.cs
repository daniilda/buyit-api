using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minio.AspNetCore;

namespace ToxiCode.BuyIt.Api.Storage;

public static class StorageExtensions
{
    public static IServiceCollection AddGenericOptions<TOptions>(this IServiceCollection services)
        where TOptions : class
    {
        services
            .AddOptions<TOptions>()
            .Configure<IConfiguration>((options, config) => config.GetSection(typeof(TOptions).Name).Bind(options))
            .ValidateDataAnnotations();

        return services;
    }

    public static IServiceCollection SetupMinio(this IServiceCollection services, IConfiguration config)
    {
        var cephOptions = config.GetSection("CephOptions").Get<CephOptions>();

        return services
            .AddMinio(options =>
            {
                options.Endpoint = cephOptions.EndPoint!;
                options.AccessKey = cephOptions.AccessKey!;
                options.SecretKey = cephOptions.SecretKey!;
                options.ConfigureClient(x => x.WithSSL());
            })
            .AddStorageHandlers();
    }

    private static IServiceCollection AddStorageHandlers(this IServiceCollection services)
        => services
            .AddSingleton<IContentTypeProvider, FileExtensionContentTypeProvider>()
            .AddSingleton<ContentTypeProvider>()
            .AddTransient<UploadProvider>();
}