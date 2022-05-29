using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Images;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Items;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Orders;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Reviews;
using ToxiCode.BuyIt.Api.Migrations;

namespace ToxiCode.BuyIt.Api.DataLayer.Extensions
{
    public static class DataInfrastructureExtension
    {
        public static IServiceCollection AddDatabaseInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDataOptions(configuration)
                .AddScoped<IDbConnectionFactory, DbConnectionFactory>()
                .AddRepositories()
                .AddMigrator();

        private static IServiceCollection AddRepositories(this IServiceCollection services)
            => services
                .AddScoped<ItemsRepository>()
                .AddScoped<ImagesRepository>()
                .AddScoped<ReviewsRepository>()
                .AddScoped<OrdersRepository>();
    }
}