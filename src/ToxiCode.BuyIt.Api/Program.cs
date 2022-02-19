#region Services

///////////////////////////////////////////////////////
// Application services/DI Container configures ///////
///////////////////////////////////////////////////////
using ToxiCode.BuyIt.Api.DataLayer.Extensions;
using ToxiCode.BuyIt.Api.Infrastructure;
using ToxiCode.BuyIt.Api.Infrastructure.Extensions;
using ToxiCode.BuyIt.Api.TelegramLayer;
using Serilog;

var builder = WebApplication
    .CreateBuilder(args)
    .WithLocalConfiguration();
builder.Host.UseSerilog();
var services = builder.Services;

services
    .AddControllers()
    .AddNewtonsoftJson();

services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddSerilogLogger();

services
    .AddDatabaseInfrastructure(builder.Configuration);

services
    .TryAddAllOptions(builder.Configuration)
    .AddTelegramBot();

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
app.Migrate();
app.Run();


#endregion