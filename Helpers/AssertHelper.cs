
namespace PetstoreTests.Helpers
{
    public class AssertHelper()
    {

    }
}


// ApiResponse apiResponse = new ApiResponse();
//             if (response.StatusCode == HttpStatusCode.OK)
//                 try
//                 {
//                     apiResponse = JsonHelper.Deserialize<ApiResponse>(response.Content);
//                 }
//                 catch (Exception ex)
//                 {
//                     Assert.Fail($"Failed to deserialize response body to ApiResponse: {ex.Message}\nBody: {response.Content}");
//                 }
//             Assert.That(apiResponse.Code, Is.EqualTo(200), $"Unexpected API response code {apiResponse.Code}. Message: {apiResponse.Message}");