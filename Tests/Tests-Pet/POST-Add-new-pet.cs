using PetstoreTests.Helpers;
using System.Net;
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
        public async Task PostNewPet_ShouldReturn200(Pet pet)
        {
            var response = await RestClientHelper.PostAsync("/pet", pet);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"Unexpected status {response.StatusCode} for pet");

            if (response.StatusCode == HttpStatusCode.OK)
                ResponseAssertions.AssertResponseIs<Pet>(response);
        }
        
        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.GetInvalidPetJsonBody))]
        public async Task PostNewPet_ShouldReturn405(Pet pet)
        {
            var response = await RestClientHelper.PostAsync("/pet", pet);
             Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"Unexpected status {response.StatusCode} for pet" );

            if (response.StatusCode == HttpStatusCode.OK)
                ResponseAssertions.AssertResponseIs<Pet>(response);
        }
    }
}