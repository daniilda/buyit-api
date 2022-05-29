#region Services

///////////////////////////////////////////////////////
// Application services/DI Container configures ///////
///////////////////////////////////////////////////////
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using MediatR;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.OpenApi.Models;
using Serilog;
using ToxiCode.BuyIt.Api;
using ToxiCode.BuyIt.Api.Common;
using ToxiCode.BuyIt.Api.DataLayer.Extensions;
using ToxiCode.BuyIt.Api.GrpcClients;
using ToxiCode.BuyIt.Api.Kafka;
using ToxiCode.BuyIt.Api.Migrations;
using ToxiCode.BuyIt.Api.Platform;
using ToxiCode.BuyIt.Api.Platform.Middlewares;
using ToxiCode.BuyIt.Api.Storage;
using ToxiCode.BuyIt.Logistics.Api.Grpc;
using AuthenticationManager = ToxiCode.BuyIt.Api.Platform.AuthenticationManager;

var builder = WebApplication
    .CreateBuilder(args)
    .UsePlatform();

var services = builder.Services;

services.AddMediatR(typeof(Program))
    .AddControllers()
    .AddNewtonsoftJson()
    .AddJsonOptions(opt =>
    {
        opt
            .JsonSerializerOptions
            .Converters
            .Add(new JsonStringEnumConverter());
        opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

services.AddKafka(builder.Configuration);

services
    .AddEndpointsApiExplorer()
    .AddSwagger()
    .AddSerilogLogger()
    .AddAutoMapper(typeof(Program))
    .AddSingleton<LogisticsApiGrpcClient>()
    .AddScoped<IAuthenticationManager, AuthenticationManager>()
    .AddHttpClient()
    .AddHttpContextAccessor();

services
    .AddDatabaseInfrastructure(builder.Configuration);

services.AddGrpcClient<ItemsService.ItemsServiceClient>(o
    => o.Address = new Uri("http://api.logistics.buyit.txcd.xyz:10002"));
services.AddGrpcClient<OrdersService.OrdersServiceClient>(o
    => o.Address = new Uri("http://api.logistics.buyit.txcd.xyz:10002"));

services
    .AddHttpContextAccessor()
    .AddSingleton<HttpCancellationTokenAccessor>();

services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

services
    .AddGenericOptions<CephOptions>()
    .SetupMinio(builder.Configuration);

#endregion

#region App

///////////////////////////////////////////////////////
// Application middlewares and entrypoint /////////////
///////////////////////////////////////////////////////

var app = builder.Build();

app.UseMiddleware<SwaggerUrlPortAuthMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization(); 
app.MapControllers();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
if (args.FirstOrDefault() == "migrate")
{
    app.Migrate();
    return;
}
await app.RunAsync();

#endregion