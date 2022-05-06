using Dapper;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Pictures.Cmds.InsertPictures;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Pictures.Cmds.InsertPicturesForItems;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Pictures.Cmds.UpdatePicturesForItem;

namespace ToxiCode.BuyIt.Api.DataLayer.Repositories.Pictures;

public class PicturesRepository : IRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public PicturesRepository(IDbConnectionFactory dbConnectionFactory)
        => _dbConnectionFactory = dbConnectionFactory;

    public async Task InsertPicturesAsync(InsertPicturesCmd cmd, CancellationToken cancellationToken)
    {
        const string insertPicturesQuery = @"INSERT INTO images 
                                                        (id, file_name, description, url)
                                                     VALUES (@Id, @FileName, @Description, @Url)";

        await using var connection = _dbConnectionFactory.CreateDatabase().Connection;
        await connection.OpenAsync(cancellationToken);

        await connection.ExecuteAsync(insertPicturesQuery, cmd.Pictures
            .Select(x => new
            {
                x.Id,
                x.FileName,
                x.Description,
                x.Url
            }));
    }

    public async Task InsertPicturesForItemAsync(InsertPicturesForItemCmd cmd, CancellationToken cancellationToken)
    {
        const string insertPicturesForItemQuery = @"INSERT INTO items_images
                                                         (item_id, image_id)
                                                     VALUES (@ItemId, @ImageId)";

        await using var connection = _dbConnectionFactory.CreateDatabase().Connection;
        await connection.OpenAsync(cancellationToken);


        await connection.ExecuteAsync(insertPicturesForItemQuery, cmd.Pictures.Select(x => new
        {
            cmd.ItemId,
            ImageId = x.Id
        }));
    }

    public async Task UpdatePicturesForItemAsync(UpdatePicturesForItemCmd cmd, CancellationToken cancellationToken)
    {
        const string deleteOldPicturesForItemQuery = @"DELETE FROM items_images WHERE item_id = @ItemId";
        const string insertPicturesForItemQuery = @"INSERT INTO items_images
                                                         (item_id, image_id)
                                                     VALUES (@ItemId, @ImageId)";
        
        await using var connection = _dbConnectionFactory.CreateDatabase().Connection;
        await connection.OpenAsync(cancellationToken);
        var transaction = await connection.BeginTransactionAsync(cancellationToken);

        try
        {
            await connection.ExecuteAsync(deleteOldPicturesForItemQuery, new
            {
                cmd.ItemId
            }, transaction);

            await connection.ExecuteAsync(insertPicturesForItemQuery, cmd.Pictures.Select(x => new
            {
                cmd.ItemId,
                ImageId = x.Id
            }), transaction);

            await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}