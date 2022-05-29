namespace ToxiCode.BuyIt.Api.Storage;

public class CephException : Exception
{
    public CephException(int statusCode)
        : base($"Ceph response code {statusCode}")
    {
    }
}