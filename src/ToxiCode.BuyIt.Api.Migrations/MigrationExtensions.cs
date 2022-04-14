using System.Reflection;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ToxiCode.BuyIt.Api.Common;

namespace ToxiCode.BuyIt.Api.Migrations;

public static class MigrationExtension
{
    public static IServiceCollection AddMigrator(this IServiceCollection services)
    {
        var servicesProvider = services.BuildServiceProvider();
        var connectionString = servicesProvider.GetService<IOptions<PostgresqlConnectionOptions>>()?.Value.BuildConnectionString();
        
        return services.AddFluentMigratorCore()
            .ConfigureRunner(x
                => x.AddPostgres()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations())
            .AddLogging(y => y.AddFluentMigratorConsole());
    }
    
    public static IApplicationBuilder Migrate(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var runner = scope.ServiceProvider.GetService<IMigrationRunner>();
        runner!.ListMigrations();
        runner.MigrateUp();
        return app;
    }       
}