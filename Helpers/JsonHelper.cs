// using Newtonsoft.Json;
using System.IO;
using System.Text.Json;
using RestSharp;

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
        /// <summary>
        /// Метод проверяет, что десериализующий объект является типом Т
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="restResponse"></param>
        public static async void CheckThatResponsedBodyIsT<T>(RestResponse restResponse)
        {
            Assert.That(restResponse.Content, Is.Not.Null.And.Not.Empty, "Responsed body is null or empty");
            T deserializedObject;
            try
            {
                deserializedObject = JsonHelper.Deserialize<T>(restResponse.Content);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failed to deserialize response body to {typeof(T).Name}: {ex.Message}");
                return;
            }

            Assert.That(deserializedObject, Is.Not.Null, $"Deserialized object of type {typeof(T).Name} is null");
            Assert.That(deserializedObject, Is.InstanceOf<T>(), $"Response body is not of type {typeof(T).Name}");
        }
    }
}