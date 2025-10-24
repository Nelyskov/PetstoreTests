using System.Text.Json;

namespace PetstoreTests.Helpers
{
    public static class JsonHelper
    {
        /// <summary>
        /// Default JsonSerializer options used for serialization and deserialization.
        /// </summary>
        private static readonly JsonSerializerOptions DefaultOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        public static string Serialize<T>(T obj)
        {
            return JsonSerializer.Serialize(obj, DefaultOptions);
        }

        public static T? Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json, DefaultOptions);
        }
    }
}