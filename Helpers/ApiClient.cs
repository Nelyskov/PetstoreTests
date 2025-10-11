// using System.Text;
// using System.Text.Json;

// namespace PetstoreTests.Helpers
// {
//     public class ApiClient
//     {
//         private readonly HttpClient _client;

//         public ApiClient(string baseUrl = "https://petstore.swagger.io/v2/")
//         {
//             _client = new HttpClient { BaseAddress = new System.Uri(baseUrl) };
//         }

//         private StringContent SerializeJson<T>(T obj) => new(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");

//         public Task<HttpResponseMessage> GetAsync(string endpoint) => _client.GetAsync(endpoint);

//         public Task<HttpResponseMessage> PostAsync<T>(string endpoint, T body) => _client.PostAsync(endpoint, SerializeJson(body));

//         public Task<HttpResponseMessage> PutAsync<T>(string endpoint, T body) => _client.PutAsync(endpoint, SerializeJson(body));

//         public Task<HttpResponseMessage> DeleteAsync(string endpoint) => _client.DeleteAsync(endpoint);
//     }
// }