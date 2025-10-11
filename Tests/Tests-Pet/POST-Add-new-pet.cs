using PetstoreTests.Helpers;
using System.Net;
using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using PetstoreTests.TestData;
using PetstoreTests.Models;


namespace PetstoreTests.Tests
{
    [AllureSuite("Pet API")]
    [AllureSubSuite("Post New Pet")]
    public class PostNewPetTest : BaseTest
    {
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

            if (response.StatusCode == HttpStatusCode.OK)
                ResponseAssertions.AssertResponseIs<Pet>(response);
        }
    }
}