using ToxiCode.BuyIt.Api.Dtos;

namespace ToxiCode.BuyIt.Api.DataLayer.Repositories.Pictures.Cmds.InsertPicturesForItems;

public class InsertPicturesForItemCmd
{
    public long ItemId { get; set; }
    
    public Picture[] Pictures { get; set; } = Array.Empty<Picture>();
}