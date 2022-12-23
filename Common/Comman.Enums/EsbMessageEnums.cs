using Utility.Attributes;

namespace Common.Enums
{
    public enum EsbsMessages
    {
        [IntValueAttribute(100)]
        ServerUnavailable = 100,

        [IntValueAttribute(105)]
        BlockUser = 105,

        [IntValueAttribute(104)]
        BlockUserPassword = 104,

        [IntValueAttribute(101)]
        UnableToProcessRequest,

        [IntValueAttribute(103)]
        UnableToParseLogin


    }
}
