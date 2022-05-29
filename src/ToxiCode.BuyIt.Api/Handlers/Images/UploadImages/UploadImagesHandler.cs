using MediatR;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Images;
using ToxiCode.BuyIt.Api.DataLayer.Repositories.Images.Cmds.InsertPictures;
using ToxiCode.BuyIt.Api.Dtos;
using ToxiCode.BuyIt.Api.Handlers.Images.UploadImages.Dtos;
using ToxiCode.BuyIt.Api.Storage;

namespace ToxiCode.BuyIt.Api.Handlers.Images.UploadImages;

public class UploadImagesHandler : IRequestHandler<AddImagesCommand, AddImagesResponse>
{
    private readonly ImagesRepository _repository;
    private readonly UploadProvider _uploadProvider;

    public UploadImagesHandler(ImagesRepository repository, UploadProvider uploadProvider)
    {
        _repository = repository; 
        _uploadProvider = uploadProvider;
    }

    public async Task<AddImagesResponse> Handle(AddImagesCommand request, CancellationToken cancellationToken)
    {
        var uploadedFiles = new List<UploadFileResponse>();
        
        var files = request.Files.Select(async x =>
        {
            await using var stream = x.OpenReadStream();
            var fileId = Guid.NewGuid();
            var uploadFileCmd = new UploadStreamMessageCmd
            {
                FileName = x.FileName,
                Stream = stream,
                FileId = fileId
            };
            uploadedFiles.Add(await _uploadProvider.UploadFileAsync(uploadFileCmd, cancellationToken));
        });

        await Task.WhenAll(files.ToArray());
        
        var cephResult = uploadedFiles.Select(x => new Image
        {
            FileName = x.OriginalFileName,
            Id = x.FileId,
            Description = "File uploaded to ceph",
            Url = x.Url
        }).ToArray();
        
        await _repository.InsertImagesAsync(new InsertImagesCmd(cephResult), cancellationToken);
        
        return new AddImagesResponse(cephResult);
    }
}