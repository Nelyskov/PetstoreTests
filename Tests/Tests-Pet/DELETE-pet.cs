using PetstoreTests.Helpers;
using System.Net;
using Allure.NUnit.Attributes;
using PetstoreTests.TestData;


namespace PetstoreTests.Tests
{
    [AllureSuite("Pet API")]
    [AllureSubSuite("Delete Pet")]
    public class DeletePetTests : BaseTest
    {
        // [TestCaseSource(typeof(PetTestData), nameof(PetTestData.GetPetsId))]
        // public async Task DeletePetByID_ShouldReturnExpectedStatus(long id)
        // {
        //     var response = await RestClientHelper.DeleteAsync($"/pet/{id}");
        //     Assert.That(
        //         response.StatusCode == HttpStatusCode.OK
        //         || response.StatusCode == HttpStatusCode.BadRequest
        //         || response.StatusCode == HttpStatusCode.NotFound,
        //         Is.True,
        //         $"Unexpected status {response.StatusCode} for id={id}"
        //     );
        //     if (response.StatusCode == HttpStatusCode.OK)
        //         ResponseAssertions.AssertApiResponse(response, 200);       
        // }

        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.GetPetsId))]
        [AllureTag("Positive")]
        public async Task DeleteExistingPet_ShouldReturn200(long id)
        {
            var response = await RestClientHelper.DeleteAsync($"/pet/{id}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                $"Expected 200 OK, but got {response.StatusCode} for id={id}");

            ResponseAssertions.AssertApiResponse(response, 200);
        }

        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.GetUnexistedPetsId))]
        [AllureTag("Negative")]
        public async Task DeleteNonExistingPet_ShouldReturn404(long id)
        {
            var response = await RestClientHelper.DeleteAsync($"/pet/{id}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound),
                $"Expected 404 NotFound, but got {response.StatusCode} for id={id}");
        }

        [TestCaseSource(typeof(PetTestData), nameof(PetTestData.GetInvalidPetsId))]
        [AllureTag("Negative")]
        public async Task DeleteInvalidPetId_ShouldReturn400(string id)
        {
            var response = await RestClientHelper.DeleteAsync($"/pet/{id}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest),
                $"Expected 400 BadRequest, but got {response.StatusCode} for id={id}");
        }
    }
}
