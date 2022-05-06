using ToxiCode.BuyIt.Api.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Pictures.AddPictures.Dtos;

public record AddPicturesResponse(IEnumerable<Picture> Pictures);