using MediatR;

namespace ToxiCode.BuyIt.Api.Handlers.Images.UploadImages.Dtos;

public record AddImagesCommand(FormFileCollection Files) : IRequest<AddImagesResponse>;