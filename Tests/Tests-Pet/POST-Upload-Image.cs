using PetstoreTests.Helpers;
using System.Net;
using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using PetstoreTests.TestData;
using PetstoreTests.Models;
using Microsoft.CodeAnalysis;

namespace PetstoreTests.Tests
{
    [TestFixture]
    [AllureSuite("Pet API")]
    [AllureSubSuite("Upload Image")]
    public class PostUploadImage : BaseTest
    {
        [Test(Description = "Update pet")]
        [AllureTag("API", "pet", "POST", "Upload Image", "200")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Nikita")]
        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.PostUploadImageToPet))]
        public async Task PostUpdatePet_ShouldReturn200(UploadFileObjectToPet uploadFile)
        {
            var response = await RestClientHelper.PostUploadPetImageAsync(uploadFile.Id, uploadFile.FilePath, uploadFile.ResponsedParametrs);

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
    }
}