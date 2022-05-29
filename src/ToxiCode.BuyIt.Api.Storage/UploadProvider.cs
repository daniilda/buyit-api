using Microsoft.Extensions.Options;
using Minio;

namespace ToxiCode.BuyIt.Api.Storage;

public class UploadProvider
{
    private readonly CephOptions _cephOptions;
    private readonly MinioClient _client;
    private readonly ContentTypeProvider _contentTypeProvider;

    public UploadProvider(
        MinioClient client,
        ContentTypeProvider contentTypeProvider,
        IOptions<CephOptions> options)
    {
        _client = client;
        _contentTypeProvider = contentTypeProvider;
        _cephOptions = options.Value;
    }

    public async Task<UploadFileResponse> UploadFileAsync(
        UploadStreamMessageCmd request,
        CancellationToken cancellationToken)
    {
        var key = await UploadAsync(request.FileName, request.Stream, request.FileId, cancellationToken);
        var url = CephHelper.GetFileUrl(_cephOptions.Path!, _cephOptions.BucketName!, key);
        return new UploadFileResponse(url, request.FileName, request.FileId);
    }

    private async Task<string> UploadAsync(string fileName, Stream stream, Guid fileId, CancellationToken cancellationToken)
    {
        var key = CephHelper.GetNewCephKey(fileName, fileId);
        var contentType = _contentTypeProvider.GetContentType(fileName);
        var putObjArgs = new PutObjectArgs()
            .WithBucket(_cephOptions.BucketName)
            .WithStreamData(stream)
            .WithObject(key)
            .WithContentType(contentType)
            .WithObjectSize(stream.Length);

        await _client.PutObjectAsync(putObjArgs, cancellationToken);
        return key;
    }
}