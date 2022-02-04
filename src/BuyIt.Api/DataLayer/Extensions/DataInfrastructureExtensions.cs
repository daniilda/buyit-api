using BuyIt.Api.DataLayer.Repositories;

namespace BuyIt.Api.DataLayer.Extensions
{
    public static class DataInfrastructureExtension
    {
        public static IServiceCollection AddDatabaseInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDataOptions(configuration)
                .AddSingleton<IDbConnectionFactory, DbConnectionFactory>()
                .AddSingleton<TelegramRepository>()
                .AddSingleton<DbExecuteWrapper>()
                .AddMigrator();
    }
}