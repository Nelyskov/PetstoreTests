using RestSharp;
using System.Threading.Tasks;
using System.Text.Json;
using PetstoreTests.Config;
using System.Globalization;
using PetstoreTests.Models;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace PetstoreTests.Helpers
{
    /// <summary>
    /// Класс RestClientHelper выполняет API запросы и возвращает ответ типа Task<RestResponse>
    /// </summary>
    public static class RestClientHelper
    {
        private static readonly TestConfiguration _config = new();

        public static async Task<RestResponse> GetAsync(string endpoint) // Get API метод 
        {
            // var client = new RestClient(_config.BaseUrl);
            // var request = new RestRequest(endpoint, Method.Get);
            // return await client.ExecuteAsync(request);

            return await new RestClient(_config.BaseUrl).ExecuteAsync(new RestRequest(endpoint, Method.Get));
        }

        public static async Task<RestResponse> GetAsync(string endpoint, params (string key, string value)[] parameters) // Get API метод с кортежом параметров
        {
            var client = new RestClient(_config.BaseUrl);
            var request = new RestRequest(endpoint, Method.Get);

            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    request.AddQueryParameter(param.key, param.value);
                }
            }

            return await client.ExecuteAsync(request);
        }

        public static async Task<RestResponse> PostAsync(string endpoint, object body) // Post API метод с передачей тела без параметров
        {
            var client = new RestClient(_config.BaseUrl);
            var request = new RestRequest(endpoint, Method.Post).AddJsonBody(body);
            return await client.ExecuteAsync(request);
        }
        public static async Task<RestResponse> PutAsync(string endpoint, object body)
        {
            var client = new RestClient(_config.BaseUrl);
            var request = new RestRequest(endpoint, Method.Put).AddJsonBody(body);
            return await client.ExecuteAsync(request);
        }

        public static async Task<RestResponse> DeleteAsync(string endpoint)
        {
            // var client = new RestClient(_config.BaseUrl);
            // var request = new RestRequest(endpoint, Method.Delete);
            // return await client.ExecuteAsync(request);

            return await new RestClient(_config.BaseUrl).ExecuteAsync(new RestRequest(endpoint, Method.Delete));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="petId">ID питомца</param>
        /// <param name="filePath">Путь к файлу</param>
        /// <param name="parameters">Дополнительные параметры в виде ключ-значение</param>
        /// <returns></returns>
        public static async Task<RestResponse> PostUploadPetImageAsync(long petId, string filePath, params (string key, string value)[] parameters)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found: {filePath}");

            var client = new RestClient(_config.BaseUrl);
            var request = new RestRequest($"/pet/{petId}/UploadImage", Method.Post);

            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    request.AddQueryParameter(param.key, param.value);
                }
            }

            request.AddFile(Path.GetFileName(filePath), filePath, Path.GetExtension(filePath));
            return await client.ExecuteAsync(request);
        }

    }
}