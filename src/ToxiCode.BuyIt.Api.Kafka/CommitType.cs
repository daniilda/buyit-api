namespace ToxiCode.BuyIt.Api.Kafka;

public enum CommitType
{
    /// <summary>
    /// Store offsets for autocommit
    /// </summary>
    ConfluentAuto,

    /// <summary>
    /// Call commit
    /// </summary>
    Immediate,
}