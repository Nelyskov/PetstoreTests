using PetstoreTests.Models;
using RestSharp;

namespace PetstoreTests.Helpers
{
    public static class ResponseAssertions
    {
        /// <summary>
        /// Проверяет, что тело ответа десериализуется в тип T; падает тест с подробным сообщением в случае ошибки.
        /// </summary>
        public static T AssertResponseIs<T>(RestResponse response)
        {
            Assert.That(response.Content, Is.Not.Null.And.Not.Empty, "Response body is null or empty");

            T? obj;
            try
            {
                obj = JsonHelper.Deserialize<T>(response.Content!);
            }
            catch (System.Exception ex)
            {
                Assert.Fail($"Failed to deserialize response body to {typeof(T).Name}: {ex.Message}\nBody: {response.Content}");
                return default!;
            }

            Assert.That(obj, Is.Not.Null, $"Deserialized {typeof(T).Name} is null");
            Assert.That(obj, Is.InstanceOf<T>(), $"Response body is not of type {typeof(T).Name}");
            return obj;
        }

        public static ApiResponse? TryGetApiResponse(RestResponse response, int expectedStatusCode)
        {
            var apiResponse = AssertResponseIs<ApiResponse>(response);
            Assert.That(apiResponse.Code, Is.EqualTo(expectedStatusCode), $"Unexpected API response code {apiResponse.Code}. Message: {apiResponse.Message}");
            return apiResponse;
        }
        
        public static ApiResponse AssertApiResponse(RestResponse response, int expectedCode)
        {
            var apiResponse = AssertResponseIs<ApiResponse>(response);
            Assert.That(apiResponse.Code, Is.EqualTo(expectedCode), $"Unexpected API response code {apiResponse.Code}. Message: {apiResponse.Message}");
            return apiResponse;
        }
    }
}