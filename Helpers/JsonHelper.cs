// using Newtonsoft.Json;
using System.IO;
using System.Text.Json;

namespace PetstoreTests.Helpers
{
    public static class JsonHelper
    {
        /// <summary>
        /// Метод который сериализует object типа T в string. Используется параметром Indented
        ///     var pet = new Pet { Id = 1, Name = "Doggie" };
        ///     string json = JsonHelper.Serialize(pet);
        /// </summary>

        public static string Serialize<T>(T serializebelObject)
        {
            return JsonSerializer.Serialize((serializebelObject, new JsonSerializerOptions { WriteIndented = true }));
        }
        /// <summary>
        /// Метод который десериализующий строку json в object типа T (Подробнее об объектах для десиарилизации в PetStoreTests/Models)
        ///     Pet petFromJson = JsonHelper.Deserialize<Pet>(json);
        /// </summary>
        public static T Deserialize<T>(string jsonData)
        {
            return JsonSerializer.Deserialize<T>(jsonData);
        }
    }
}