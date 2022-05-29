using Dapper;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Images.Cmds.InsertPictures;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Images.Cmds.InsertPicturesForItems;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Images.Cmds.UpdatePicturesForItem;
using ToxiCode.BuyIt.Api.Dtos;

namespace ToxiCode.BuyIt.Api.DataLayer.Repositories.Images;

public class ImagesRepository : IRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public ImagesRepository(IDbConnectionFactory dbConnectionFactory)
        => _dbConnectionFactory = dbConnectionFactory;

    public async Task<IEnumerable<Image>> GetImagesByItemId(long itemId, CancellationToken cancellationToken)
    {
        const string getItemPicturesQuery = @"SELECT i.id, i.file_name FileName, i.description, i.url
                                               FROM items_images im 
                                               INNER JOIN images i ON i.id = im.image_id
                                               WHERE item_id = @Id;";
        
        await using var connection = _dbConnectionFactory.CreateDatabase().Connection;
        await connection.OpenAsync(cancellationToken);

        return await connection.QueryAsync<Image>(getItemPicturesQuery, new {Id = itemId});
    }
    
    public async Task<IEnumerable<string>> GetUrlsByImageIds(Guid[] imageIds, CancellationToken cancellationToken)
    {
        const string getItemPicturesQuery = @"SELECT i.url
                                               WHERE i.id = ANY(@Ids);";
        
        await using var connection = _dbConnectionFactory.CreateDatabase().Connection;
        await connection.OpenAsync(cancellationToken);

        return await connection.QueryAsync<string>(getItemPicturesQuery, new {Ids = imageIds});
    }

    public async Task InsertImagesAsync(InsertImagesCmd cmd, CancellationToken cancellationToken)
    {
        const string insertImagesQuery = @"INSERT INTO images 
                                                        (id, file_name, description, url)
                                                     VALUES (@Id, @FileName, @Description, @Url)";

        await using var connection = _dbConnectionFactory.CreateDatabase().Connection;
        await connection.OpenAsync(cancellationToken);

        await connection.ExecuteAsync(insertImagesQuery, cmd.Pictures
            .Select(x => new
            {
                x.Id,
                x.FileName,
                x.Description,
                x.Url
            }));
    }

    public async Task InsertImagesForItemAsync(InsertPicturesForItemCmd cmd, CancellationToken cancellationToken)
    {
        const string insertPicturesForItemQuery = @"INSERT INTO items_images
                                                         (item_id, image_id)
                                                     VALUES (@ItemId, @ImageId)";

        await using var connection = _dbConnectionFactory.CreateDatabase().Connection;
        await connection.OpenAsync(cancellationToken);


        await connection.ExecuteAsync(insertPicturesForItemQuery, cmd.ImagesIds.Select(x => new
        {
            cmd.ItemId,
            ImageId = x
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