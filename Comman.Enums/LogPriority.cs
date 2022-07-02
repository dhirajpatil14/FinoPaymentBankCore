using Utility.Attributes;

namespace Common.Enums
{
    public enum LogPriority
    {
        [IntValueAttribute(1)]
        Exception = 1,
        [IntValueAttribute(2)]
        BL1 = 2,
        [IntValueAttribute(3)]
        BL2 = 3,
        [IntValueAttribute(4)]
        BL3 = 4,
        [IntValueAttribute(5)]
        BL4 = 5,
    }
}
