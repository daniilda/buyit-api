using Microsoft.Extensions.Options;
using Npgsql;
using ToxiCode.BuyIt.Api.Infrastructure;
using ToxiCode.BuyIt.Api.Infrastructure.Options;

namespace ToxiCode.BuyIt.Api.DataLayer;

public class DbConnectionFactory : IDbConnectionFactory
{
    private readonly HttpCancellationTokenAccessor _cancellationTokenAccessor;
    private readonly PostgresqlConnectionOptions _options;

    public DbConnectionFactory(
        HttpCancellationTokenAccessor cancellationTokenAccessor,
        IOptions<PostgresqlConnectionOptions> options)
    {
        _cancellationTokenAccessor = cancellationTokenAccessor;
        _options = options.Value;
    }

    public DatabaseWrapper CreateDatabase(CancellationToken? cancellationToken = default)
        => new(
            new NpgsqlConnection(_options.BuildConnectionString()),
            cancellationToken ?? _cancellationTokenAccessor.Token);

}