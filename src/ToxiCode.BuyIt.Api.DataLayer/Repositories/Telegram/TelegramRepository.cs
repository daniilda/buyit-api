namespace ToxiCode.BuyIt.Api.DataLayer.Repositories.Telegram;

public class TelegramRepository : IRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public TelegramRepository(IDbConnectionFactory dbConnectionFactory) 
        => _dbConnectionFactory = dbConnectionFactory;
}