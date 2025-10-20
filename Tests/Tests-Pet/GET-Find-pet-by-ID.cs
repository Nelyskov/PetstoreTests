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
    [AllureSuite("Pet API")]
    [AllureSubSuite("Get Pet by ID")]
    public class GetPetByIDTests : BaseTest
    {
        // [TestCaseSource(typeof(PetTestData), nameof(PetTestData.GetPetsId))]
        // public async Task GetPetById_ShouldReturnExpectedStatus(long id)
        // {
        //     var response = await RestClientHelper.GetAsync($"/pet/{id}");

        //     Assert.That(
        //         response.StatusCode == HttpStatusCode.OK
        //         || response.StatusCode == HttpStatusCode.BadRequest
        //         || response.StatusCode == HttpStatusCode.NotFound,
        //         Is.True,
        //         $"Unexpected status {response.StatusCode} for id={id}"
        //     );

        //     if (response.StatusCode == HttpStatusCode.OK)
        //         ResponseAssertions.AssertResponseIs<Pet>(response);
        // }

        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.GetPetsId))]
        [AllureTag("Positive")]
        public async Task GetExistingPet_ShouldReturn200(long id)
        {
            var response = await RestClientHelper.GetAsync($"/pet/{id}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                $"Expected 200 OK, but got {response.StatusCode} for id={id}");

            ResponseAssertions.AssertApiResponse(response, 200);
        }

        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.GetUnexistedPetsId))]
        [AllureTag("Negative")]
        public async Task GetNonExistingPet_ShouldReturn404(long id)
        {
            var response = await RestClientHelper.GetAsync($"/pet/{id}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound),
                $"Expected 404 NotFound, but got {response.StatusCode} for id={id}");
        }

        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.GetInvalidPetsId))]
        [AllureTag("Negative")]
        public async Task GetInvalidPetId_ShouldReturn400(string id)
        {
            var response = await RestClientHelper.GetAsync($"/pet/{id}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest),
                $"Expected 400 BadRequest, but got {response.StatusCode} for id={id}");
        }
    }
}