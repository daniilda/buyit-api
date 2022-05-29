using ToxiCode.BuyIt.Api.Dtos;

namespace ToxiCode.BuyIt.Api.DataLayer.Repositories.Images.Cmds.InsertPicturesForItems;

public class InsertPicturesForItemCmd
{
    public long ItemId { get; set; }
    
    public IEnumerable<Guid> ImagesIds { get; set; } = Array.Empty<Guid>();
}