using PetstoreTests.Helpers;
using System.Net;
using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using PetstoreTests.TestData;
using PetstoreTests.Models;
using RestSharp;


namespace PetstoreTests.Tests
{
    [TestFixture]
    [AllureSuite("Pet API")]
    [AllureSubSuite("PUT update an existing pet")]
    public class UpdateAnExistingPet : BaseTest
    {
        [Test(Description = "Update pet")]
        [AllureTag("API", "pet", "PUT")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Nikita")]
        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.GetPetJsonBody))]
        public async Task PostNewPet_ShouldReturnExpectedStatus(Pet pet)
        {
            var response = await RestClientHelper.PutAsync("/pet", pet);
            Assert.That(
                response.StatusCode == HttpStatusCode.OK
                || response.StatusCode == HttpStatusCode.BadRequest
                || response.StatusCode == HttpStatusCode.NotFound
                || response.StatusCode == HttpStatusCode.MethodNotAllowed,
                Is.True,
                $"Unexpected API response code {response.StatusCode}."
            );

            CheckThatResponsedBodyIsPet(response);
        }

        public async void CheckThatResponsedBodyIsPet(RestResponse restResponse)
        {
            Pet pet = new Pet();
            try
            {

                pet = JsonHelper.Deserialize<Pet>(restResponse.Content);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failed to deserialize response body to Pet: {ex.Message}\nBody: {restResponse.Content}");
            }

            Assert.That(pet, Is.InstanceOf<Pet>(), "Response contains non-Pet objects");
        }
    }
}