using Newtonsoft.Json;

namespace WinterCubeTimer.util {
    public class Serializer {
        public static string serialize<T>(T obj) {
            return JsonConvert.SerializeObject(obj);
        }

        public static T deserialize<T>(string json) {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}