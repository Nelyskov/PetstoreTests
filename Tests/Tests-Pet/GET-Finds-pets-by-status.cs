using PetstoreTests.Helpers;
using System.Net;
using Allure.Net.Commons;
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
        public async Task FindPetByStatus_ShouldReturnExpectedStatus(string petStatus)
        {
            var response = await RestClientHelper.GetAsync("/pet/findByStatus", ("status", petStatus));
            Assert.That(
                response.StatusCode == HttpStatusCode.OK
                || response.StatusCode == HttpStatusCode.BadRequest,
                Is.True,
                $"Unexpected status {response.StatusCode} for status={petStatus}"
            );

            if (response.StatusCode == HttpStatusCode.OK)
                ResponseAssertions.AssertResponseIs<List<Pet>>(response);
        }
    }
}