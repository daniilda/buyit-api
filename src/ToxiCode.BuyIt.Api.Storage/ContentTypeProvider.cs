using Microsoft.AspNetCore.StaticFiles;

namespace ToxiCode.BuyIt.Api.Storage;

public class ContentTypeProvider
{
    private readonly IContentTypeProvider _contentTypeProvider;

    public ContentTypeProvider(IContentTypeProvider contentTypeProvider)
        => _contentTypeProvider = contentTypeProvider;

    public string GetContentType(string fileName)
    {
        var fileExtension = Path.GetExtension(fileName).ToLower();
        if (_contentTypeProvider.TryGetContentType(fileName, out var standardContentType))
            return standardContentType;

        throw new UnknownTypeException(fileExtension);
    }
}
