using Utility.Attributes;

namespace Common.Enums
{
    public enum ResponseCode
    {
        [IntValueAttribute(0)]
        Success = 0,
        [IntValueAttribute(1)]
        Failure = 1,
        [IntValueAttribute(3)]
        Error = 3,
        [IntValueAttribute(99)]
        RemoteServerError = 99,
        [IntValueAttribute(100)]
        RecoredNotfound = 100,
        [IntValueAttribute(1012)]
        InvalidResponse = 1012,
        [IntValueAttribute(405)]
        NotAllowed = 405
    }
}
