using ToxiCode.BuyIt.Api.Dtos;

namespace ToxiCode.BuyIt.Api.DataLayer.Repositories.Images.Cmds.UpdatePicturesForItem;

public class UpdatePicturesForItemCmd
{
    public long ItemId { get; set; }
    
    public Image[] Pictures { get; set; } = Array.Empty<Image>();
}