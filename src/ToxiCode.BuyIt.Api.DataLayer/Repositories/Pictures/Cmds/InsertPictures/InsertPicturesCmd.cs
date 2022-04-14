using ToxiCode.BuyIt.Api.Dtos;

namespace ToxiCode.BuyIt.Api.DataLayer.Repositories.Pictures.Cmds.InsertPictures;

public record InsertPicturesCmd(IEnumerable<Picture> Pictures);