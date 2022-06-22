using Utility.Attributes;

namespace Common.Enums
{
    public enum ExcelDataType
    {
        [IntValueAttribute(0)]
        General = 0,
        [IntValueAttribute(0)]
        Number = 1,
        [IntValueAttribute(0)]
        Decimal = 2,
        [IntValueAttribute(0)]
        Currency = 164,
        [IntValueAttribute(0)]
        Accounting = 44,
        [IntValueAttribute(0)]
        DateShort = 14,
        [IntValueAttribute(0)]
        DateLong = 165,
        [IntValueAttribute(0)]
        Time = 166,
        [IntValueAttribute(0)]
        Percentage = 10,
        [IntValueAttribute(0)]
        Fraction = 12,
        [IntValueAttribute(0)]
        Scientific = 11,
        [IntValueAttribute(0)]
        Text = 49

    }
}
