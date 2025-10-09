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
    [AllureSubSuite("Find Pet by status")]
    public class PostNewPetTest : BaseTest
    {
        [Test(Description = "Post pet")]
        [AllureTag("API", "pet", "POST")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Nikita")]
        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.GetPetJsonBody))]
        public async Task PostNewPet_ShouldReturnExpectedStatus(Pet pet)
        {
            var response = await RestClientHelper.PostAsync("/pet", pet);
            Assert.That(
                response.StatusCode == HttpStatusCode.OK
                || response.StatusCode == HttpStatusCode.MethodNotAllowed,
                Is.True,
                $"Unexpected status {response.StatusCode} for pet"
            );
        }
    }
}