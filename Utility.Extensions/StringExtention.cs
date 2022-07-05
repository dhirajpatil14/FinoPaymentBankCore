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
            if (base64String is not null)
            {
                if (base64String.Contains(","))
                {
                    base64String = base64String[(base64String.IndexOf(",") + 1)..];
                }
                return Convert.FromBase64String(base64String);
            }
            else
            {
                return Convert.FromBase64String(string.Empty);
            }

        }


        public static string ToBase64Decode(this string base64EncodeData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodeData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }


        public static string ToBase64String(this byte[] baseByte)
        {
            return Convert.ToBase64String(baseByte);
        }

    }
}
