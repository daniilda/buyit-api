using ToxiCode.BuyIt.Api.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Images.UploadImages.Dtos;

public record AddImagesResponse(IEnumerable<Image> Pictures);