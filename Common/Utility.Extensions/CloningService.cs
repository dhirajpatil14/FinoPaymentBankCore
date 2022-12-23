using Newtonsoft.Json;

namespace Utility.Extensions
{
    public static class CloningService
    {
        public static T Clone<T>(this T source)
        {
            // Don't serialize a null object, simply return the default for that object
            if (source is null)
            {
                return default;
            }
            var deserializeSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };
            var serializeSettings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source, serializeSettings), deserializeSettings);
        }
    }
}
