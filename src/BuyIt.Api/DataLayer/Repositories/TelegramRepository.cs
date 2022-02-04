namespace BuyIt.Api.DataLayer.Repositories;

public class TelegramRepository : IRepository
{
    private readonly DbExecuteWrapper _dbExecuteWrapper;

    public TelegramRepository(DbExecuteWrapper dbExecuteWrapper)
        => _dbExecuteWrapper = dbExecuteWrapper;
    
}