using RestSharp;
using PetstoreTests.Config;

namespace PetstoreTests.Helpers
{
    /// <summary>
    /// Класс RestClientHelper выполняет API запросы и возвращает ответ типа Task<RestResponse>
    /// </summary>
    public static class RestClientHelper
    {
        private static readonly TestConfiguration _config = new();
        private static async Task<RestResponse> ExecuteAsync(string endpoint, Method method, object? body = null, params (string key, string value)[] parameters)
        {
            var client = new RestClient(_config.BaseUrl);
            var request = new RestRequest(endpoint, method);

            if (parameters != null)
                foreach (var (key, value) in parameters)
                    request.AddQueryParameter(key, value);

            if (body != null)
                request.AddJsonBody(body);

            return await client.ExecuteAsync(request);
        }

        public static async Task<RestResponse> GetAsync(string endpoint, params (string key, string value)[] parameters)
        {
            return await ExecuteAsync(endpoint, Method.Get, null, parameters);
        }
        public static async Task<RestResponse> PostAsync(string endpoint, object jsonBody)
        {
            return await ExecuteAsync(endpoint, Method.Post, jsonBody, null);
        }
        public static async Task<RestResponse> PutAsync(string endpoint, object jsonBody)
        {
            return await ExecuteAsync(endpoint, Method.Put, jsonBody, null);
        }
        public static async Task<RestResponse> DeleteAsync(string endpoint)
        {
            return await ExecuteAsync(endpoint, Method.Delete, null, null);
        }

        public static async Task<RestResponse> PostUploadPetImageASync(long petId, string filePath, params (string key, string value)[] parameters)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File not found by pat: {filePath}");
            }
            var client = new RestClient(_config.BaseUrl);
            var request = new RestRequest($"/pet/{petId}/UploadImage", Method.Post);

            foreach (var param in parameters)
                request.AddQueryParameter(param.key, param.value);

            request.AddFile(Path.GetFileName(filePath), filePath, Path.GetExtension(filePath));

            return await client.ExecuteAsync(request);
        }
    }
}