using PetstoreTests.Helpers;
using System.Net;
using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using RestSharp;
using System.Text.Json;
using PetstoreTests.TestData;
using PetstoreTests.Models;

namespace PetstoreTests.Tests
{
    [TestFixture]
    [AllureSuite("Pet API")]
    [AllureSubSuite("Find Pet by status")]
    public class FindPetByStatusTests : BaseTest
    {
        [Test(Description = "Find pet by status")]
        [AllureTag("API", "pet", "GET")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Nikita")]
        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.GetPetsStatus))]
        public async Task FindPetByStatus_ShouldReturnExpectedStatus(string petStatus)
        {
            var response = await RestClientHelper.GetAsync($"/pet/findByStatus", "status", petStatus);
            Assert.That(
                response.StatusCode == HttpStatusCode.OK
                || response.StatusCode == HttpStatusCode.BadRequest,
                Is.True,
                $"Unexpected status {response.StatusCode} for status={petStatus}"
            );

            if (response.StatusCode == HttpStatusCode.OK)
                try
                {
                    JsonHelper.Deserialize<Pet>(response.Content);
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Failed to deserialize response body to Pet: {ex.Message}\nBody: {response.Content}");
                }
            Assert.That(response.Content, Is.InstanceOf<Pet>(), "Response contains non-Pet objects");
        }

    }
}