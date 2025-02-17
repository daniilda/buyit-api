﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToxiCode.BuyIt.Api.Common;
using static ToxiCode.BuyIt.Api.DataLayer.DatabaseEnvironmentConstants;
using static ToxiCode.BuyIt.Api.Common.EnvironmentConstants;


namespace ToxiCode.BuyIt.Api.DataLayer.Extensions;

public static class DatabaseEnvironmentOptionsExtensions
{
    public static IServiceCollection AddDataOptions(this IServiceCollection services, IConfiguration configuration)
    {
        var isRunningInContainer =
            Environment.GetEnvironmentVariable(IsRunningInContainer)?.Equals("true") ?? false;
        if (isRunningInContainer)
        {
            return services.Configure<PostgresqlConnectionOptions>(x =>
            {
                x.Database = configuration[DatabaseName];
                x.Host = configuration[DatabaseHost];
                x.Password = configuration[DatabasePassword];
                x.Pooling = configuration[DatabasePooling] is null ? x.Pooling : configuration[DatabasePooling];
                x.Port = configuration[DatabasePort] is null ? x.Port : configuration[DatabasePort];
                x.Username = configuration[DatabaseUser];
                x.ConnectionLifetime = configuration[DatabaseConnectionLifetime] is null
                    ? x.ConnectionLifetime
                    : configuration[DatabaseConnectionLifetime];
                x.MaxPoolSize = configuration[DatabaseMaxPoolSize] is null
                    ? x.MaxPoolSize
                    : configuration[DatabaseMaxPoolSize];
                x.MinPoolSize = configuration[DatabaseMinPoolSize] is null
                    ? x.MinPoolSize
                    : configuration[DatabaseMinPoolSize];
            });
        }

        services
            .AddOptions<PostgresqlConnectionOptions>()
            .Bind(configuration.GetSection(nameof(PostgresqlConnectionOptions)));

        return services;
    }
}