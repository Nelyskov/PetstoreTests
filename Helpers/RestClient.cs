using RestSharp;
using System.Threading.Tasks;
using System.Text.Json;
using PetstoreTests.Config;
using System.Globalization;

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

        public static async Task<RestResponse> PostAsync(string endpoint, object body) // Post API метод с передачей тела
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

    }
}