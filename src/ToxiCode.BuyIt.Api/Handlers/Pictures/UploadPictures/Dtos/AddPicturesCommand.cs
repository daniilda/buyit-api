using MediatR;

namespace ToxiCode.BuyIt.Api.Handlers.Pictures.AddPictures.Dtos;

public record AddPicturesCommand(FormFileCollection Files) : IRequest<AddPicturesResponse>;