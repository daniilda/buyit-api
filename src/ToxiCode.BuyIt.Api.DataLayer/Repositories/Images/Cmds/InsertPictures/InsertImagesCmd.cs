using ToxiCode.BuyIt.Api.Dtos;

namespace ToxiCode.BuyIt.Api.DataLayer.Repositories.Images.Cmds.InsertPictures;

public record InsertImagesCmd(IEnumerable<Image> Pictures);