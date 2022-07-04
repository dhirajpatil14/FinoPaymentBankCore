using Utility.Attributes;

namespace Common.Enums
{
    public enum LayerType
    {
        [IntValueAttribute(1)]
        UI = 1,
        [IntValueAttribute(2)]
        BLL = 2,
        [IntValueAttribute(3)]
        ESB = 3,
        [IntValueAttribute(101)]
        NewUI = 101,
    }
}
