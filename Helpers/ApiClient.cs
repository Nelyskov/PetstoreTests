using System.Net.Http;
using RestSharp;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace PetstoreTests.Helpers
{
    public class ApiClient
    {
        private readonly HttpClient _client;
        public ApiClient()
        {
            _client = new HttpClient { BaseAddress = new System.Uri("https://petstore.swagger.io/v2/") };
        }

        public async Task<HttpResponseMessage> GetAsync(string endpoint)
        {
            return await _client.GetAsync(endpoint);
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string endpoint, T body)
        {
            var json = JsonSerializer.Serialize(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _client.PostAsync(endpoint, content);
        }
        public async Task<HttpResponseMessage> PutAsync<T>(string endpoint, T body)
        {
            var json = JsonSerializer.Serialize(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _client.PutAsync(endpoint, content);
        }
        public async Task<HttpResponseMessage> DeleteAsync(string endpoint)
        {
            return await _client.DeleteAsync(endpoint);
        }
    }
}