using System;

namespace Utility.Extensions
{
    public static class StringExtention
    {

        public static bool IsEmpty(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }
            return false;
        }

        public static string ToTitleCase(this string str) => string.IsNullOrEmpty(str) || str.Length < 2 ? str
              : char.ToUpperInvariant(str[0]) + str[1..];
        public static byte[] ToConvertBase64ToByte(this string base64String)
        {
            if (base64String != null)
            {
                if (base64String.Contains(","))
                {
                    base64String = base64String[(base64String.IndexOf(",") + 1)..];
                }
                return Convert.FromBase64String(base64String);
            }
            else
            {
                return null;
            }

        }


    }
}
