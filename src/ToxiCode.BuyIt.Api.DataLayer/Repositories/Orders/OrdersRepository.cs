using Dapper;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Orders.Cmds.InsertOrder;
using ToxiCode.BuyIt.Api.Dtos;

namespace ToxiCode.BuyIt.Api.DataLayer.Repositories.Orders;

public class OrdersRepository : IRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public OrdersRepository(IDbConnectionFactory dbConnectionFactory) 
        => _dbConnectionFactory = dbConnectionFactory;

    public Task InsertOrder(InsertOrderCmd cmd, CancellationToken cancellationToken)
    {
        const string insertOrderQuery = @"INSERT INTO orders (id, user_id) VALUES (@OrderId, @UserId)";
        var connection = _dbConnectionFactory.CreateDatabase().Connection;

        return connection.ExecuteAsync(insertOrderQuery, cmd);
    }

    public Task<IEnumerable<long>> GetOrdersIdsByUserId(Guid userId, CancellationToken cancellationToken)
    {
        const string getOrders = @"SELECT id FROM orders WHERE user_id = @Id";
        var connection = _dbConnectionFactory.CreateDatabase().Connection;

        return connection.QueryAsync<long>(getOrders, new {Id = userId});
    }
}