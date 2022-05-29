namespace ToxiCode.BuyIt.Api.Handlers.Facade.GetFrontPageAggregation.Dtos;

public class Banner
{
    public Banner(string imageUrl, string redirectUrl)
    {
        ImageUrl = imageUrl;
        RedirectUrl = redirectUrl;
    }
    
    public string ImageUrl { get; set; } = null!;

    public string RedirectUrl { get; set; } = null!;

    public static Banner GetByCategoryKey(long category)
    {
        return category switch
        {
            1 => new Banner("https://cdn1.ozone.ru/s3/cms/cf/t23/wc2900/1416x100x2_4.jpg", "#"),
            2 => new Banner("https://cdn1.ozone.ru/s3/cms/fe/te5/wc2900/1416x100x2.jpg", "#"),
            3 => new Banner("https://cdn1.ozone.ru/s3/cms/e5/ta7/wc2900/1416x156x2_2.jpg","#"),
            _ => new Banner("https://cdn1.ozone.ru/s3/cms/c6/tef/wc2900/candy_2832_200_1-min.jpg", "#")
        };
    }
}