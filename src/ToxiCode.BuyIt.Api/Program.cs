#region Services

///////////////////////////////////////////////////////
// Application services/DI Container configures ///////
///////////////////////////////////////////////////////
using System.Text.Json.Serialization;
using MediatR;
using Serilog;
using ToxiCode.BuyIt.Api.Common;
using ToxiCode.BuyIt.Api.DataLayer.Extensions;
using ToxiCode.BuyIt.Api.Migrations;

var builder = WebApplication
    .CreateBuilder(args)
    .WithLocalConfiguration();
builder.Host.UseSerilog();
var services = builder.Services;

services.AddMediatR(typeof(Program))
    .AddControllers()
    .AddNewtonsoftJson()
    .AddJsonOptions(opt => opt
        .JsonSerializerOptions
        .Converters
        .Add(new JsonStringEnumConverter()));

services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddSerilogLogger()
    .AddAutoMapper(typeof(Program));

services
    .AddDatabaseInfrastructure(builder.Configuration);

services
    .AddHttpContextAccessor()
    .AddSingleton<HttpCancellationTokenAccessor>();
#endregion

#region App

///////////////////////////////////////////////////////
// Application middlewares and entrypoint /////////////
///////////////////////////////////////////////////////

var app = builder.Build();
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