using PetstoreTests.Helpers;
using System.Net;
using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using PetstoreTests.TestData;
using PetstoreTests.Models;
using RestSharp;


namespace PetstoreTests.Tests
{
    [AllureSuite("Pet API")]
    [AllureSubSuite("PUT Update Existing Pet")]
    public class UpdateAnExistingPet : BaseTest
    {
        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.GetPetJsonBody))]
        public async Task PutUpdatePet_ShouldReturnExpectedStatus(Pet pet)
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

            if (response.StatusCode == HttpStatusCode.OK)
                ResponseAssertions.AssertResponseIs<Pet>(response);
        }

    }
}