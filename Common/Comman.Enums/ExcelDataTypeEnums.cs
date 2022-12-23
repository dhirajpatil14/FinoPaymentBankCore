using Utility.Attributes;

namespace Common.Enums
{
    public enum ExcelDataType
    {
        [IntValueAttribute(0)]
        General = 0,
        [IntValueAttribute(1)]
        Number = 1,
        [IntValueAttribute(2)]
        Decimal = 2,
        [IntValueAttribute(164)]
        Currency = 164,
        [IntValueAttribute(44)]
        Accounting = 44,
        [IntValueAttribute(14)]
        DateShort = 14,
        [IntValueAttribute(165)]
        DateLong = 165,
        [IntValueAttribute(166)]
        Time = 166,
        [IntValueAttribute(10)]
        Percentage = 10,
        [IntValueAttribute(12)]
        Fraction = 12,
        [IntValueAttribute(11)]
        Scientific = 11,
        [IntValueAttribute(49)]
        Text = 49

    }
}
