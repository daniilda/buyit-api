using System.Net.Http.Headers;

namespace ToxiCode.BuyIt.Api.Storage;

using System;
using System.IO;

public static class CephHelper
{
    public static string GetNewCephKey(string fileName)
    {
        var fileGuid = Guid.NewGuid();
        return $"{fileGuid}{Path.GetExtension(fileName)}";
    }
    
    public static string GetNewCephKey(string fileName, Guid fileGuid) 
        => $"{fileGuid}{Path.GetExtension(fileName)}";

    public static string GetFileUrl(string path, string bucketName, string key)
        => $"{path}/{bucketName}/{key}";
}