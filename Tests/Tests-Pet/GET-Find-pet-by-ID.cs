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
                ResponseAssertions.AssertResponseIs<Pet>(response);
        }
    }
}