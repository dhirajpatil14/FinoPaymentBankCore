using Newtonsoft.Json;

namespace Utility.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJsonSerialize<T>(this T TObject)
        {
            if (TObject is not null)
                return JsonConvert.SerializeObject(TObject, Newtonsoft.Json.Formatting.None);
            else
                return string.Empty;
        }

        public static T ToJsonDeSerialize<T>(this string TObject)
        {
            return JsonConvert.DeserializeObject<T>(TObject);

        }


    }


}
