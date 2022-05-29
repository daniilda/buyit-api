using System.Text;
using Dapper;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Reviews.Cmds.GetReview;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Reviews.Cmds.GetReviewsByItemId;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Reviews.Cmds.InsertReviewByItemId;
using ToxiCode.BuyIt.Api.Dtos;
using ToxiCode.BuyIt.Api.Dtos.Pagination;

namespace ToxiCode.BuyIt.Api.DataLayer.Repositories.Reviews;

public class ReviewsRepository : IRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public ReviewsRepository(IDbConnectionFactory dbConnectionFactory) 
        => _dbConnectionFactory = dbConnectionFactory;

    public async Task<GetReviewCmdResponse> GetReviewAsync(GetReviewCmd cmd, CancellationToken cancellationToken)
    {
        const string getReviewByIdQuery = @"SELECT 
                                            id,
                                            rate AS Rating, 
                                            review_text_cons AS ReviewTextCons, 
                                            review_text_pros AS ReviewTextPros, 
                                            review_text_commentary AS Commentary, 
                                            user_id AS UserId
                                            FROM reviews
                                            WHERE id = @Id";
        
        await using var connection = _dbConnectionFactory.CreateDatabase().Connection;
        await connection.OpenAsync(cancellationToken);

        var result = await connection.QueryFirstOrDefaultAsync<Review>(getReviewByIdQuery, new
        {
            cmd.Id
        });

        return new GetReviewCmdResponse(result);
    }

    public async Task<GetReviewsByItemIdCmdResponse> GetReviewsByItemIdAsync(
        GetReviewsByItemIdCmd cmd,
        CancellationToken cancellationToken)
    {
        const string getReviewByIdQuery = @"SELECT id,
                                            rate Rating, 
                                            review_text_cons ReviewTextCons, 
                                            review_text_pros ReviewTextPros, 
                                            review_text_commentary Commentary, 
                                            user_id UserId
                                            FROM reviews
                                            WHERE item_id = @ItemId
                                            LIMIT @Count 
                                            OFFSET @Offset;";

        const string paginationResponseQuery = @"SELECT COUNT(1) Amount FROM reviews WHERE item_id = @ItemId";
        
        await using var connection = _dbConnectionFactory.CreateDatabase().Connection;
        await connection.OpenAsync(cancellationToken);

        var result = await connection.QueryAsync<Review>(getReviewByIdQuery, new
        {
            cmd.ItemId,
            cmd.Pagination.Count,
            cmd.Pagination.Offset
        });

        var paginationResponse = await connection.QueryFirstOrDefaultAsync<PaginationResponse>(paginationResponseQuery, new
        {
            cmd.ItemId
        });

        return new GetReviewsByItemIdCmdResponse(result, paginationResponse);
    }

    public async Task InsertReviewByItemId(InsertReviewByItemIdCmd cmd, CancellationToken cancellationToken)
    {
        const string insertReviewByItemIdQuery = @"INSERT INTO reviews
                                            (rate, review_text_cons, review_text_pros, review_text_commentary, user_id, item_id)
                                            VALUES (@Rate, @ReviewTextCons, @ReviewTextPros, @ReviewTextCommentary, @UserId, @ItemId)";
        
        await using var connection = _dbConnectionFactory.CreateDatabase().Connection;
        await connection.OpenAsync(cancellationToken);

        await connection.ExecuteAsync(insertReviewByItemIdQuery, new
        {
            Rate = (short) cmd.Rating,
            cmd.ReviewTextCons,
            cmd.ReviewTextPros,
            ReviewTextCommentary = cmd.Commentary,
            cmd.UserId,
            cmd.ItemId
        });
    }
}