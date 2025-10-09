using System.Net;
using System.Text.Json;
using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using PetstoreTests.Helpers;
using PetstoreTests.Models;
using PetstoreTests.TestData;
using RestSharp;

namespace PetstoreTests.Tests
{
    [TestFixture]
    [AllureSuite("Pet API")]
    [AllureSubSuite("Get Pet by ID")]
    public class GetPetByIDTests : BaseTest
    {
        [Test(Description = "Get pet by ID")]
        [AllureTag("API", "pet", "GET")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Nikita")]
        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.GetPetsId))]
        public async Task GetPetById_ShouldReturnExpectedStatus(long id)
        {
            var response = await RestClientHelper.GetAsync($"/pet/{id}");
            Assert.That(
                response.StatusCode == HttpStatusCode.OK
                || response.StatusCode == HttpStatusCode.BadRequest
                || response.StatusCode == HttpStatusCode.NotFound,
                Is.True,
                $"Unexpected status {response.StatusCode} for id={id}"
            );

            if (response.StatusCode == HttpStatusCode.OK)
                CheckThatResponsedBodyIsPet(response);
        }

        public async void CheckThatResponsedBodyIsPet(RestResponse restResponse)
        {
            Pet pet = new Pet();
            try
            {

                pet = JsonSerializer.Deserialize<Pet>(restResponse.Content);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failed to deserialize response body to Pet: {ex.Message}\nBody: {restResponse.Content}");
            }

            Assert.That(pet, Is.InstanceOf<Pet>(), "Response contains non-Pet objects");
        }
        
    }
}