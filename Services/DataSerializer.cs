using Newtonsoft.Json;
using System.Text;

namespace Services
{
    public static class DataSerializer
    {
        public static byte[] SerializeToByte<T>(T obj)
        {
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });

            return Encoding.UTF8.GetBytes(json);
        }
        public static T DeserializeObject<T>(byte[] bytes)
        {
            string json = Encoding.UTF8.GetString(bytes);
            return JsonConvert.DeserializeObject<T>(json, new Newtonsoft.Json.JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
        }
    }
}
