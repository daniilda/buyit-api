using MediatR;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Pictures;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Pictures.Cmds.InsertPictures;
using ToxiCode.BuyIt.Api.Dtos;
using ToxiCode.BuyIt.Api.Handlers.Pictures.AddPictures.Dtos;

namespace ToxiCode.BuyIt.Api.Handlers.Pictures.AddPictures;

public class AddPicturesHandler : IRequestHandler<AddPicturesCommand, AddPicturesResponse>
{
    private readonly PicturesRepository _repository;

    public AddPicturesHandler(PicturesRepository repository) 
        => _repository = repository;

    public async Task<AddPicturesResponse> Handle(AddPicturesCommand request, CancellationToken cancellationToken)
    {
        // TODO: Uploading to CEPH
        // Mocking it for now...
        var cephResult = request.Files.Select(x => new Picture
        {
            FileName = "SomePic.png",
            Id = Guid.NewGuid(),
            Description = "MockedPicture",
            Url = "https://somemockedurl.ru/fsdfs-gerg34-sfsdf.png"
        }).ToArray();
        await _repository.InsertPicturesAsync(new InsertPicturesCmd(cephResult), cancellationToken);
        
        return new AddPicturesResponse(cephResult);
    }
}