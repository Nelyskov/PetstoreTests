using PetstoreTests.Helpers;
using System.Net;
using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using PetstoreTests.TestData;
using PetstoreTests.Models;

namespace PetstoreTests.Tests
{
    [TestFixture]
    [AllureSuite("Pet API")]
    [AllureSubSuite("Update pet with Form Data")]
    public class PostUpdatePetWithFormData : BaseTest
    {
        [Test(Description = "Update pet")]
        [AllureTag("API", "pet", "POST", "Update", "200")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Nikita")]
        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.PostPetFormToUpdate))]
        public async Task PostUpdatePet_ShouldReturn200(JsonBodyToUpdatePet jsonBodyToUpdatePet)
        {
            var response = await RestClientHelper.PostAsync($"/pet/{jsonBodyToUpdatePet.Id}", jsonBodyToUpdatePet);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"Unexpected status {response.StatusCode}, but expected 200 with JSONBODY");

            ApiResponse apiResponse = new ApiResponse();
            if (response.StatusCode == HttpStatusCode.OK)
                try
                {
                    apiResponse = JsonHelper.Deserialize<ApiResponse>(response.Content);
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Failed to deserialize response body to ApiResponse: {ex.Message}\nBody: {response.Content}");
                }
            Assert.That(apiResponse.Code, Is.EqualTo(200), $"Unexpected API response code {apiResponse.Code}. Message: {apiResponse.Message}");
        }
        [Test(Description = "Update pet")]
        [AllureTag("API", "pet", "POST", "Update", "404")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Nikita")]
        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.PostPetFormToUpdate))]
        public async Task PostUpdatePet_ShouldReturn404(JsonBodyToUpdatePet jsonBodyToUpdatePet)
        {
            var response = await RestClientHelper.PostAsync($"/pet/{jsonBodyToUpdatePet.Id}", jsonBodyToUpdatePet);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"Unexpected status {response.StatusCode}, but expected 200 with JSONBODY");

            ApiResponse apiResponse = new ApiResponse();
            if (response.StatusCode == HttpStatusCode.OK)
                try
                {
                    apiResponse = JsonHelper.Deserialize<ApiResponse>(response.Content);
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Failed to deserialize response body to ApiResponse: {ex.Message}\nBody: {response.Content}");
                }
            Assert.That(apiResponse.Code, Is.EqualTo(404), $"Unexpected API response code {apiResponse.Code}. Message: {apiResponse.Message}");
        }
        
        [Test(Description = "Update pet")]
        [AllureTag("API", "pet", "POST", "Update", "405")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Nikita")]
        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.PostPetFormToUpdate))]
        public async Task PostUpdatePet_ShouldReturn405(JsonBodyToUpdatePet jsonBodyToUpdatePet)
        {
            var response = await RestClientHelper.PostAsync($"/pet/{jsonBodyToUpdatePet.Id}", jsonBodyToUpdatePet);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"Unexpected status {response.StatusCode}, but expected 200 with JSONBODY");

            ApiResponse apiResponse = new ApiResponse();
            if (response.StatusCode == HttpStatusCode.OK)
                try
                {
                   apiResponse = JsonHelper.Deserialize<ApiResponse>(response.Content);
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Failed to deserialize response body to ApiResponse: {ex.Message}\nBody: {response.Content}");
                }
            Assert.That(apiResponse.Code, Is.EqualTo(405), $"Unexpected API response code {apiResponse.Code}. Message: {apiResponse.Message}");
        }
    }
}