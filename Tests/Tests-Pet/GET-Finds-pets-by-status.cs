using PetstoreTests.Helpers;
using System.Net;
using Allure.NUnit.Attributes;
using PetstoreTests.TestData;
using PetstoreTests.Models;

namespace PetstoreTests.Tests
{
    [AllureSuite("Pet API")]
    [AllureSubSuite("Find Pet by status")]
    public class FindPetByStatusTests : BaseTest
    {
        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.GetPetsStatus))]
        public async Task FindPetByStatus_ShouldReturn200(string petStatus)
        {
            var response = await RestClientHelper.GetAsync("/pet/findByStatus", ("status", petStatus));
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
               $"Expected 200 OK, but got {response.StatusCode} for status={petStatus}");

            if (response.StatusCode == HttpStatusCode.OK)
                ResponseAssertions.AssertResponseIs<List<Pet>>(response);
        }

        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.GetPetsUnexistedStatus))]
        public async Task FindPetByStatus_ShouldReturn400(string petStatus)
        {
            var response = await RestClientHelper.GetAsync("/pet/findByStatus", ("status", petStatus));
             Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest),
                $"Expected 400 OK, but got {response.StatusCode} for status={petStatus}");

        }
    }
}